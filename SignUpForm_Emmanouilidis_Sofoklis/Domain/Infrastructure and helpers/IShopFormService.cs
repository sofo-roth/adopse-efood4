using Domain.ValueModels;


namespace Domain.Infrastructure
{
    public interface IShopFormService
    {
        ShopFormViewModel Read(int shopId);
    }
}
