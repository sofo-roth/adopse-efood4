using Domain.Infrastructure;
using Domain.ValueModels;

namespace Domain.Services
{
    public class ShopFormService : UserCartService, IShopFormService
    {


        public ShopFormService() : base() { }


        public ShopFormViewModel Read(int shopId)
        {
            var id = UserInfo.UserId;

            var canRate = id <= 0 ? false : _ordersRepository.CanRate(id, shopId);

            var model = _repository.Read(id, shopId, canRate);

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
