﻿using Domain.ValueModels;
using System.Collections.Generic;

namespace Domain.Infrastructure
{
    public interface IUserAccountService : IServiceBase
    {
        int CreateUser(UserInformation user);

        int CreateUserShopOwner(UserInformation user, ShopInformation shop);

        void Update(UserInformation user);

        void UpdateWithNewPassword(UserInformation user, string oldPassword);

        bool VerifyUserPassword(string providedPassword, string hashedPassword);

        bool LoginUser(string userName, string password);

        void SetUserInfo(UserInformation info);

        IEnumerable<OrderDetails> GetUserOrders();

        List<OrderItemViewModel> GetOrderItems(int orderId);
    }
}
