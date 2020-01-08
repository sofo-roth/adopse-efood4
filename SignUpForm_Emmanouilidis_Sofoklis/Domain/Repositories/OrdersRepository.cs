using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;
using Domain.ValueModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    internal sealed class OrdersRepository : SqlContextBase
    {
        public bool CanRate(int userId, int shopId)
        {
            var canRate = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = "SELECT COUNT(*) FROM Orders WHERE ShopId = @shopId AND UserId = @userId; ";
                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@shopId", shopId);
                    command.Parameters.AddWithValue("@userId", userId);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        canRate = true;
                        break;
                    }

                }
                connection.Close();
            }
            return canRate;
        }

        public List<OrderDetails> Read(int userId)
        {
            
            var orders = new List<OrderDetails>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT Orders.UserId,Orders.OrderId, Orders.ShopId, Orders.UserAddress, Orders.Comments, Orders.OrderTime, Orders.Delivered, Orders.Canceled, Orders.FinalPrice, Shop.Name as shopName" +
                            "FROM Orders WHERE Orders.UserId = @userId AND Orders.Delivered=1 AND Orders.Canceled=0 " +
                            "INNER JOIN Shop on Shop.ShopId=Orders.ShopId";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    var reader = command.ExecuteReader();

                    orders = GetOrders(reader).ToList();

                }
                connection.Close();

            }
            return orders;
        }

        public List<OrderItemViewModel> ReadLines(int orderId)
        {
            var orders = new List<OrderItemViewModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var sql = @"SELECT * FROM OrderLines WHERE OrderId = @orderId " +
                            "INNER JOIN Ingredients on Ingredients.IngId=OrderLines.IngredientId " +
                            "INNER JOIN ShopPriceIngredient on ShopPriceIngredient.IngId=Ingredients.IngId; "+
                            
                            "SELECT * FROM OrderLines WHERE OrderId = @orderId " +
                            "INNER JOIN FoodItem on FoodItem.ItemId=OrderLines.FoodItemId " +
                            "INNER JOIN ShopPriceFoodItem on ShopPriceFoodItem.FoodItemId=FoodItem.ItemId; ";
                using (var command = new MySqlCommand(sql, connection))
                {
                    
                    command.Parameters.AddWithValue("@orderId", orderId);

                    var reader = command.ExecuteReader();

                    var ingredients = GetIngredients(reader);

                    reader.NextResult();

                    orders = GetFoodItems(reader, ingredients).ToList(); ;

                }
                connection.Close();

            }
            return orders;
        }


        public void MakeOrder(IEnumerable<CartItem> items, OrderDetails ord)
        {
            var orderDto = new Orders();
            

            PropertyCopier<OrderDetails, Orders>.Copy(ord, orderDto);

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {

                    try
                    {
                        var orderId = InsertOrder(orderDto, connection, transaction);
                        
                        foreach(var cartItem in items)
                        {
                            var orderLineFoodItemDto = new OrderLines();
                            PropertyCopier<CartItem, OrderLines>.Copy(cartItem, orderLineFoodItemDto);

                            orderLineFoodItemDto.OrderId = orderId;
                            var parentId = InsertOrder(orderLineFoodItemDto, connection, transaction);

                            foreach(var cartItemIngredient in cartItem.Ingredients)
                            {
                                var orderLineIngredientDto = new OrderLines();
                                PropertyCopier<CartItemIngredient, OrderLines>.Copy(cartItemIngredient, orderLineIngredientDto);

                                orderLineIngredientDto.OrderId = orderId;
                                orderLineIngredientDto.ParentId = parentId;

                                InsertOrder(orderLineIngredientDto, connection, transaction);

                            }
                        }

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
        
        private IEnumerable<OrderDetails> GetOrders(MySqlDataReader reader)
        {
            while (reader.Read())
            {
                var dto = CreateInstance<Orders>(reader);

                var model = new OrderDetails();

                PropertyCopier<Orders, OrderDetails>.Copy(dto, model);

                model.ShopName = reader.GetString("shopName");

                yield return model;
            }
        }



        private IEnumerable<OrderItemViewModel> GetIngredients(MySqlDataReader reader)
        {
            while (reader.Read())
            {
                var ingredient = new OrderItemViewModel
                {
                    Name = reader.GetString("IName"),
                    IngId = reader.GetInt32("IngId"),
                    Price = reader.GetDouble("Price"),
                    ParentId = reader.GetInt32("ParentId")
                };

                yield return ingredient;
            }
        }

        private IEnumerable<OrderItemViewModel> GetFoodItems(MySqlDataReader reader, IEnumerable<OrderItemViewModel> ingredients)
        {
            while (reader.Read())
            {

                var lineId = reader.GetInt32("LineId");
                var foodItem = new OrderItemViewModel
                {
                    ItemId = reader.GetInt32("ItemId"),
                    Name = reader.GetString("ItemName"),
                    Price = reader.GetDouble("Price"),
                    FoodIngredients = ingredients.Where(x => x.ParentId == lineId).ToList()
                };

                yield return foodItem;
            }
        }

        private int InsertOrder<T>(T dto, MySqlConnection connection, MySqlTransaction transaction)
        {
            int id = -1;

            var script = GetInsertScript(dto);
            using (var command = new MySqlCommand(script, connection, transaction))
            {

                command.ExecuteNonQuery();
                id = (int)command.LastInsertedId;
            }

            if (id <= 0) throw new Exception("Could not commit new order");
            return id;
        }
    }
}
