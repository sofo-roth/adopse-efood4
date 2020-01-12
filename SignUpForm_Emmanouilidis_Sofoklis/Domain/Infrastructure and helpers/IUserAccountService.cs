using Domain.ValueModels;
using System.Collections.Generic;

namespace Domain.Infrastructure
{
    public interface IUserAccountService : IUserCartService
    {
        int CreateUser(UserInformation user);

        int CreateUserShopOwner(UserInformation user, ShopInformation shop);

        void Update(UserInformation user);

        void UpdateWithNewPassword(UserInformation user);

        string RetrieveHash(string pwd);

        bool VerifyUserPassword(string providedPassword, string hashedPassword);

        bool LoginUser(string userName, string password);

        void SetUserInfo(UserInformation info);

        List<OrderDetailsGridViewModel> GetUserOrders();

        List<OrderItemViewModel> GetOrderItems(int orderId);
    }
}
