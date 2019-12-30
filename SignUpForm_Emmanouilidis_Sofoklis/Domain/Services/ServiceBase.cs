using Domain.AccountManager;
using Domain.Cart;
using Domain.Repositories;
using Domain.ValueModels;
using System.Collections.Generic;

namespace Domain.Services
{
    public abstract class ServiceBase
    {
        public UserInformation UserInfo => UserIdentity.Instance;

        public CartCollection Cart => CartCollection.GetInstance;

        private readonly RepositoryBase _repository;


        public ServiceBase()
        {
            _repository = new RepositoryBase();
        }

        public void CheckOut(OrderDetails ord)
        {
            var items = GetCartItems();

            _repository.MakeOrder(items,ord);
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
