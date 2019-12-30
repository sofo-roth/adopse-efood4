using Domain.Context;
using Domain.DatabaseModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using ValueModels;

namespace Domain.Repositories
{
    internal class ShopResultsRepository : SqlContextBase
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
                                                ShopName = x.Name,
                                                Categories = (from s in shopFoodCategories
                                                             where s.ShopId == x.ShopId
                                                             select s.CategoryId).ToList()                                            
                                             });

            return shopsDto;

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
