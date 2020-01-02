using Domain.Infrastructure;
using Domain.Repositories;
using Domain.ValueModels;

namespace Domain.Services
{
    public class ShopFormService : ServiceBase, IShopFormService
    {
        private readonly ShopRepository _shopRepository;
        private readonly OrdersRepository _ordersRepository;

        public ShopFormService()
        {
            _shopRepository = new ShopRepository(); ;
            _ordersRepository = new OrdersRepository();
        }



        public ShopFormViewModel Read(int shopId)
        {
            var canRate = _ordersRepository.CanRate(UserInfo.UserId, shopId);

            var model = _shopRepository.Read(UserInfo.UserId, shopId);

            model.UserRating.isAllowed = canRate;

            return model;
        }
    }
}
