using Domain.Infrastructure;
using Domain.Repositories;
using Domain.ValueModels;

namespace Domain.Services
{
    public class ShopFormService : UserCartService, IShopFormService
    {
        
        private readonly OrdersRepository _ordersRepository;

        public ShopFormService() : base()
        {
            
            _ordersRepository = new OrdersRepository();
        }



        public ShopFormViewModel Read(int shopId)
        {
            var canRate = _ordersRepository.CanRate(UserInfo.UserId, shopId);

            var model = _repository.Read(UserInfo.UserId, shopId);

            model.UserRating.isAllowed = canRate;

            return model;
        }

        public void RateShop(int shopId, int score)
        {
            _repository.RateShop(UserInfo.UserId, shopId, score);
        }

        public void RateShopUpdate(int shopId, int score)
        {
            _repository.RateShopUpdate(UserInfo.UserId, shopId, score);
        }
    }
}
