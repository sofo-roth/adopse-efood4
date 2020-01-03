using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IShopFormService : IServiceBase
    {
        ShopFormViewModel Read(int shopId);
    }
}
