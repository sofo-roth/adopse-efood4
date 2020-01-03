using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IShopFormService : IUserCartService
    {
        ShopFormViewModel Read(int shopId);
    }
}
