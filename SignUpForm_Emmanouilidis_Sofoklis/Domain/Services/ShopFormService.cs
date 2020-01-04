using Domain.Infrastructure;
using Domain.ValueModels;

namespace Domain.Services
{
    public class ShopFormService : UserCartService, IShopFormService
    {


        public ShopFormService() : base() { }


        public ShopFormViewModel Read(int shopId)
        {
            var canRate = _ordersRepository.CanRate(UserInfo.UserId, shopId);

            var model = _repository.Read(UserInfo.UserId, shopId, canRate);

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
