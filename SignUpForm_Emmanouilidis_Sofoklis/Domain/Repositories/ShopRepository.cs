﻿using Domain.Context;
using Domain.DatabaseModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ValueModels;
using Domain.Infrastructure;
using System.Collections.ObjectModel;

namespace Domain.Repositories
{
    internal class ShopRepository : SqlContextBase
    {

        
        public IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories)
        {
            foodCategories = new Dictionary<int, string>();
            var shops = new List<Shop>();
            var shopFoodCategories = new List<ShopFoodItemCategories>(); 

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "SELECT * FROM FoodItemCategories;" +

                                "SELECT * FROM Shop WHERE IsActive = 1; " +

                                "SELECT * FROM ShopFoodItemCategories";
                using (var command = new MySqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var key = reader.GetInt32("CategoryId");
                        var value = reader.GetString("FoodType");
                        
                       
                        foodCategories.Add(key,value);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        var dto = CreateInstance<Shop>(reader);
                        shops.Add(dto);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        var dto = CreateInstance<ShopFoodItemCategories>(reader);
                        shopFoodCategories.Add(dto);
                    }

                }
            }

            var shopsDto = shops.Select(x => new ShopGridViewModel
                                             {
                                                Address = x.Address,
                                                Id = x.ShopId,
                                                Latitude = x.Latitude,
                                                Longitude = x.Longitude,
                                                ShopName = x.Name,
                                                Categories = (from s in shopFoodCategories
                                                             where s.ShopId == x.ShopId
                                                             select s.CategoryId).ToList()                                            
                                             });

            return shopsDto;

        }

        public void Create(ShopInformation shop)
        {
            var dto = new Shop();
            PropertyCopier<ShopInformation, Shop>.Copy(shop, dto);
            var script = GetInsertScripts(dto);
            ExecDbScripts(script);
        }

        public ShopFormViewModel Read(int userId, int shopId)
        {
            ShopFormViewModel model;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Shop " +
                           "WHERE Shop.ShopId = @shopId; " +

                           "SELECT * FROM ShopPriceIngredient " +
                           "WHERE ShopPriceIngredient.ShopId = @shopId " +
                           "INNER JOIN Ingredients ON Ingredients.IngId=ShopPriceIngredient.IngId " +
                           "INNER JOIN FoodCategoryIngredients ON FoodCategoryIngredients.IngredientId = Ingredients.IngId ;" +

                           "SELECT * FROM ShopPriceFoodItem " +
                           "WHERE ShopPriceFoodItem.ShopId = @shopId " +
                           "INNER JOIN FoodItem ON ShopPriceFoodItem.FoodItemId=FoodItem.ItemId; "  +

                           "SELECT * FROM FoodItemCategories; " +
                           //
                           "SELECT ShopFoodItemCategories.* FROM ShopFoodItemCategories " +
                           "WHERE ShopFoodItemCategories.ShopId = @shopId; " +

                           "SELECT * FROM ShopRatings " +
                           "WHERE ShopId = @shopId AND UserId = @userId; ";


                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);
                    command.Parameters.AddWithValue("@userId", userId);
                    

                    var reader = command.ExecuteReader();

                    model = MapToShopFormInfo(reader);

                }

            }


                return model;
        }

        private ShopFormViewModel MapToShopFormInfo(MySqlDataReader reader)
        {
            var shop = new Shop();
            var categories = new List<FoodItemCategories>();
            var shopCategoriesWithAliases = new List<ShopFoodItemCategories>();
            var shopRating = new UserShopRatingInformation();
            var ingredients = new List<FoodItemIngredientViewModel>();
            var foodItems = new List<FoodItemViewModel>();

            while (reader.Read())
            {
                shop = CreateInstance<Shop>(reader);
            }

            reader.NextResult();

            while (reader.Read())
            {
                var ingredient = new FoodItemIngredientViewModel
                {
                    IName = reader.GetString("IName"),
                    IngId = reader.GetInt32("IngId"),
                    Price = reader.GetDouble("Price"),
                    CategoryId = reader.GetInt32("CategoryId"),
                };

                ingredients.Add(ingredient);
            }

            reader.NextResult();

            while (reader.Read())
            {

                var categoryId = reader.GetInt32("CategoryId");
                var foodItem = new FoodItemViewModel
                {
                    FoodIngredients = ingredients.Where(x => x.CategoryId == categoryId).ToList(),
                    CategoryId = categoryId,
                    ItemId = reader.GetInt32("ItemId"),
                    ItemName = reader.GetString("ItemName"),
                    Price = reader.GetDouble("Price")
                };

                foodItems.Add(foodItem);
            }

            reader.NextResult();

            while (reader.Read())
            {
                var category = CreateInstance<FoodItemCategories>(reader);
                categories.Add(category);
            }

            reader.NextResult();

            while (reader.Read())
            {
                var shopCategory = CreateInstance<ShopFoodItemCategories>(reader);
                shopCategoriesWithAliases.Add(shopCategory);
            }

            reader.NextResult();

            while (reader.Read())
            {
                var userRating = CreateInstance<ShopRatings>(reader);

                shopRating.Rating = userRating.Rating;

            }

            var shopCategoriesActual = new Dictionary<int,string>();

            foreach(var category in categories)
            {
                
                var alias = shopCategoriesWithAliases.Where(x => x.CategoryId == category.CategoryId).Select(y => y.CategoryAlias).FirstOrDefault();

                if (alias != null && alias != string.Empty)
                    category.FoodType = alias;
                shopCategoriesActual.Add(category.CategoryId,category.FoodType);
            }

            return Compose(shop, shopCategoriesActual, foodItems, shopRating);
        }


        private ShopFormViewModel Compose(Shop shop, Dictionary<int,string> categories, List<FoodItemViewModel> foodItems, UserShopRatingInformation rating)
        {
            var model = new ShopFormViewModel();

            var shopModel = new ShopInformation();
            PropertyCopier<Shop, ShopInformation>.Copy(shop, shopModel);
            model.Info = shopModel;

            model.UserRating = rating;

            model.FoodItems = GetFoodItemsPerCategory(categories, foodItems);

            return model;
        }

        private Dictionary<string, List<FoodItemViewModel>> GetFoodItemsPerCategory(Dictionary<int, string> categories, List<FoodItemViewModel> foodItems)
        {
            return (from f in foodItems
                    group f by f.CategoryId into g
                    select g).ToDictionary(x=> categories[x.Key], x => x.ToList());
        }

        public void RecordClick(int userId, int shopId)
        {
            var dto = new UserClicks
                {
                ClickDate = DateTime.Now,
                ShopId = shopId,
                UserId = userId
                };

            var script = GetInsertScripts(dto);

            ExecDbScripts(script); 

        }
    }
}
