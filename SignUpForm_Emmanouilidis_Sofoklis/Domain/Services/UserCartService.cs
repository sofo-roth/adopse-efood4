using Domain.Cart;
using Domain.Infrastructure;
using Domain.Repositories;
using Domain.ValueModels;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class UserCartService : ServiceBase, IUserCartService
    {

        private readonly OrdersRepository _ordersRepository;

        public CartCollection Cart => CartCollection.GetInstance;


        public UserCartService() : base() { }

        public virtual void CheckOut(OrderDetails ord)
        {
            var cartItems = GetCartItems();


            var cartItemsPerShop = from b in cartItems
                                   group b by b.ShopId into g
                                   select g.ToList();

            foreach (var items in cartItemsPerShop)
            {
                ord.ShopId = items.FirstOrDefault().ShopId;

                ord.UserId = UserInfo.UserId > 0 ? UserInfo.UserId : (int?)null;
                _ordersRepository.MakeOrder(items, ord);
            }

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
