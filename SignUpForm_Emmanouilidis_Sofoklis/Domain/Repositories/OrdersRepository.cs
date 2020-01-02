using Domain.Context;
using Domain.DatabaseModels;
using Domain.Infrastructure;
using Domain.ValueModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Domain.Repositories
{
    internal sealed class OrdersRepository : SqlContextBase
    {
        public bool CanRate(int userId, int shopId)
        {

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
        

        private int InsertOrder(IDataTable dto, MySqlConnection connection, MySqlTransaction transaction)
        {
            int id = -1;

            var script = GetInsertScripts(dto);
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
