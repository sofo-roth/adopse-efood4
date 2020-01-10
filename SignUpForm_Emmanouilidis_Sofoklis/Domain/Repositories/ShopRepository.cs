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
    internal sealed class ShopRepository : SqlContextBase
    {
        public void RateShop(int userId, int shopId, int score)
        {
            var dto = new ShopRatings
            {
                Rating = score,
                ShopId = shopId,
                UserId = userId
            };

            var script = GetInsertScript(dto);

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {

                    try
                    {
                        using (var command = new MySqlCommand(script, connection, transaction))
                            command.ExecuteNonQuery();

                        var avg = GetShopRatings(shopId, connection, transaction).Average();

                        ShopAverageRatingUpdate(shopId, avg, connection, transaction);

                        transaction.Commit();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        throw;
                    }
                    finally
                    {
                        connection.Close();

                    }
                }
            }
        }

        public void RateShopUpdate(int userId, int shopId, int score)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {

                    try
                    {
                        var sql = "UPDATE ShopRatings SET Rating=@score WHERE ShopId=@shopId AND UserId=@userId";

                        using (var command = new MySqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@shopId", shopId);
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@score", score);

                            command.ExecuteNonQuery();

                        }

                        var avg = GetShopRatings(shopId, connection, transaction).ToList().Average();

                        ShopAverageRatingUpdate(shopId, avg, connection, transaction);

                        transaction.Commit();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        throw;
                    }
                    finally
                    {
                        connection.Close();

                    }
                }
            }
        }

        public double GetShopPrice(int shopId)
        {
            double elaxisti=0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT Elaxisti FROM Shop WHERE ShopId = @shopId; ";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        elaxisti = reader.GetDouble("Elaxisti");
                    }
                }
                connection.Close();
            }
            return elaxisti;
        }

        public IEnumerable<ShopGridViewModel> Read(string address, ref Dictionary<int, string> foodCategories)
        {
            foodCategories = new Dictionary<int, string>();
            var shops = new List<Shop>();
            var shopFoodCategories = new List<ShopFoodItemCategories>(); 

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var sql = @"SELECT * FROM FoodItemCategories;" +

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
                connection.Close();
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
            var script = GetInsertScript(dto);
            ExecDbScripts(script);
        }

        public ShopFormViewModel Read(int userId, int shopId, bool allowRating)
        {
            ShopFormViewModel model;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM Shop " +
                           "WHERE Shop.ShopId = @shopId; " +

                           "SELECT * FROM ShopPriceIngredient " +
                           "INNER JOIN Ingredients ON Ingredients.IngId=ShopPriceIngredient.IngId " +
                           "INNER JOIN FoodCategoryIngredients ON FoodCategoryIngredients.IngredientId = Ingredients.IngId " +
                           "WHERE ShopPriceIngredient.ShopId = @shopId; " +

                           "SELECT * FROM ShopPriceFoodItem " +
                           "INNER JOIN FoodItem ON ShopPriceFoodItem.FoodItemId=FoodItem.ItemId "  +
                           "WHERE ShopPriceFoodItem.ShopId = @shopId; " +

                           "SELECT * FROM FoodItemCategories; " +
                           
                           "SELECT ShopFoodItemCategories.* FROM ShopFoodItemCategories " +
                           "WHERE ShopFoodItemCategories.ShopId = @shopId; " +

                           "SELECT * FROM ShopRatings " +
                           "WHERE ShopId = @shopId AND UserId = @userId; ";

                
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);
                    command.Parameters.AddWithValue("@userId", userId);
                    

                    var reader = command.ExecuteReader();

                    model = ComposeToShopFormEntity(reader, allowRating);

                }
                connection.Close();
            }


                return model;
        }

        private IEnumerable<double> GetShopRatings(int shopId, MySqlConnection connection, MySqlTransaction transaction)
        {
                var sql = "SELECT Rating FROM ShopRatings WHERE ShopId=@shopId";

                using (var command = new MySqlCommand(sql, connection, transaction))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);
                    command.ExecuteNonQuery();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        yield return reader.GetDouble("Rating");
                    }

                }
        }

        private void ShopAverageRatingUpdate(int shopId, double avg, MySqlConnection connection, MySqlTransaction transaction)
        {
            var sql = "UPDATE Shop SET Rating=@avg WHERE ShopId=@shopId";

            using (var command = new MySqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@shopId", shopId);
                command.Parameters.AddWithValue("@avg", avg);

                command.ExecuteNonQuery();

            }
        }

        private ShopFormViewModel ComposeToShopFormEntity(MySqlDataReader reader, bool allowRating)
        {
            var shop = new Shop();
            var categories = new List<FoodItemCategories>();
            var shopCategoriesWithAliases = new List<ShopFoodItemCategories>();
            var shopRating = new UserShopRatingInformation();
            shopRating.isAllowed = allowRating;

            while (reader.Read())
            {
                shop = CreateInstance<Shop>(reader);
            }

            reader.NextResult();

            var ingredients = GetIngredients(reader).ToList();

            reader.NextResult();

            var foodItems = GetFoodItems(reader,ingredients).ToList();

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

            if (allowRating)
            {
                reader.NextResult();

                while (reader.Read())
                {
                    var userRating = CreateInstance<ShopRatings>(reader);

                    if (Enum.IsDefined(typeof(Rating), userRating.Rating))
                        shopRating.StarRating = (Rating)userRating.Rating;
                    else
                        shopRating.StarRating = Rating.None;
                }
            }
            
            var shopCategoriesActual = new Dictionary<int,string>();

            foreach(var category in categories)
            {
                
                var alias = shopCategoriesWithAliases.Where(x => x.CategoryId == category.CategoryId).Select(y => y.CategoryAlias).FirstOrDefault();

                if (alias != null && alias != string.Empty)
                    category.FoodType = alias;
                shopCategoriesActual.Add(category.CategoryId,category.FoodType);
            }

            return Compose(shop, shopCategoriesActual, foodItems.ToList(), shopRating);
        }

        private IEnumerable<FoodItemIngredientViewModel> GetIngredients(MySqlDataReader reader)
        {
            while (reader.Read())
            {
                var ingredient = new FoodItemIngredientViewModel
                {
                    IName = reader.GetString("IName"),
                    IngId = reader.GetInt32("IngId"),
                    Price = reader.GetDouble("Price"),
                    CategoryId = reader.GetInt32("CategoryId")
                };

                yield return ingredient;
            }
        }

        private IEnumerable<FoodItemViewModel> GetFoodItems(MySqlDataReader reader, IEnumerable<FoodItemIngredientViewModel> ingredients)
        {
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

                yield return foodItem;
            }
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

        
    }
}
