using Domain.Context;
using Domain.DatabaseModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ValueModels;
using Domain.Infrastructure;

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
                                "SELECT * FROM Shop;   " +
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

        public ShopFormViewModel Read(int shopId, int userId)
        {
            var shop = new Shop();
            var Categories = new FoodItemCategories();
            var shopCategoriesWithAliases = new ShopFoodItemCategories();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Shop " +
                           "WHERE Shop.ShopId = @shopId; " +
                           "SELECT * FROM FoodItemCategories; " +
                           "SELECT ShopFoodItemCategories.* FROM ShopFoodItemCategories " +
                           "INNER JOIN Shop ON Shop.ShopId= ShopFoodItemCategories.ShopId " +
                           "INNER JOIN FoodItemCategories ON FoodItemCategories.CategoryId=ShopFoodItemCategories.CategoryId;" +
                           "WHERE Shop.ShopId = @shopId;"; //todo + stuff 
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);
                    command.Parameters.AddWithValue("@userId", userId);
                    

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        shop = CreateInstance<Shop>(reader);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        Categories = CreateInstance<FoodItemCategories>(reader);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        shopCategoriesWithAliases = CreateInstance<ShopFoodItemCategories>(reader);
                    }

                    reader.NextResult();

                    //todo + stuff 

                }


            }




                return new ShopFormViewModel();
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
