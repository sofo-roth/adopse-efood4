using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IUserAccountService
    {
        void CreateUser(UserInformation user);

        void CreateUserShopOwner(UserInformation user, ShopInformation shop);

        void Update(UserInformation user);

        void UpdateWithNewPassword(UserInformation user, string oldPassword);

        void GetUserOrders();
    }
}
