using Domain.Context;
using Domain.ValueModels;

using System.Collections.Generic;


namespace Domain.Repositories
{
    internal class RepositoryBase : SqlContextBase
    {
        public void MakeOrder(IEnumerable<CartItem> items, OrderDetails ord)
        {
            //todo
        }
    }
}
