
using Domain.Cart;
using Domain.ValueModels;

namespace Domain.Infrastructure
{
    public interface IUserCartService
    {
        CartCollection Cart { get; }

        void CheckOut(OrderDetails ord);
    }
}
