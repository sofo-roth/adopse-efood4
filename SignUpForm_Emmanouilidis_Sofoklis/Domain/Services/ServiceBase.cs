using Domain.AccountManager;
using Domain.Cart;
using Domain.Repositories;
using Domain.ValueModels;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Services
{
    public abstract class ServiceBase
    {
        public static UserInformation UserInfo => UserIdentity.Instance;

        public static CartCollection Cart => CartCollection.GetInstance;

        private readonly RepositoryBase _repository;


        public ServiceBase()
        {
            _repository = new RepositoryBase();
        }

        public void CheckOut(OrderDetails ord)
        {
            var cartItems = GetCartItems();

            var cartItemsPerShop = cartItems.GroupBy(x => x.ShopId)
                                        .Select(group => group.ToList());

            foreach(var items in cartItemsPerShop)
            {
                ord.ShopId = items[0].ShopId;

                ord.UserId = UserInfo.UserId > 0 ? UserInfo.UserId : (int?)null;
                _repository.MakeOrder(items, ord);
            }
            
        }

        public void LogoutUser()
        {
            UserIdentity.SetInstance(new UserInformation());
        }

        private IEnumerable<CartItem> GetCartItems()
        {

            for (var i = 0; i < Cart.Count(); i++)
            {
                yield return Cart[i];
            }
        }

    }
}
