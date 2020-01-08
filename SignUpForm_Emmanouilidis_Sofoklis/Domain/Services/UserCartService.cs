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

        private protected readonly OrdersRepository _ordersRepository;

        public CartCollection Cart => CartCollection.GetInstance;


        public UserCartService() : base() { }

        public virtual void CheckOut(OrderDetails ord)
        {
            if (Cart.Count() == 0) return;

            var cartItems = GetCartItems();

            var userId = UserInfo.UserId > 0 ? UserInfo.UserId : (int?)null;

            var cartItemsPerShop = from b in cartItems
                                   group b by b.ShopId into g
                                   select g.ToList();

            foreach (var items in cartItemsPerShop)
            {
                var price = items.Sum(x => x.Quantity * (x.Price + x.Ingredients.Sum(y => y.Price)));

                ord.ShopId = items.FirstOrDefault().ShopId;
                ord.FinalPrice = price;
                ord.UserId = userId;

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
