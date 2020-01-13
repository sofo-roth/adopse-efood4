using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IShopFormService : IUserCartService
    {
        ShopFormViewModel Read(int shopId);

        void RateShop(int shopId, int score);

        void RateShopUpdate(int shopId, int score);
    }
}
