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
        public UserInformation UserInfo => UserIdentity.Instance;

        public CartCollection Cart => CartCollection.GetInstance;

        private readonly OrdersRepository _repository;


        public ServiceBase()
        {
            _repository = new OrdersRepository();
        }

        public void CheckOut(OrderDetails ord)
        {
            var cartItems = GetCartItems();


            var cartItemsPerShop = from b in cartItems
                                   group b by b.ShopId into g
                                   select g.ToList();

            foreach (var items in cartItemsPerShop)
            {
                ord.ShopId = items.FirstOrDefault().ShopId;

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
