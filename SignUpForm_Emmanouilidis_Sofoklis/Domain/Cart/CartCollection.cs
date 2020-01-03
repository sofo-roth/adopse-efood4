using Domain.Infrastructure;
using Domain.ValueModels;
using System.Collections.Generic;


namespace Domain.Cart
{
    public sealed class CartCollection
    {
        private static CartCollection _cart = null;
        private static readonly object _padlock = new object();

        private List<CartItem> _items;


        private CartCollection()
        {

            _items = new List<CartItem>();
        }


        public CartItem this[int index]
        {
            get
            {
                return _items.Count > index ? _items[index] : null;
            }
            set
            {
                _items[index] = value;
            }
        }

        public void Add(CartItem item)
        {
            _items.Add(item);
            
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }


        public int Count()
        {
            return _items.Count;
        }

        public static CartCollection GetInstance
        {
            get
            {
                if (_cart == null)
                {
                    lock (_padlock)
                    {
                        if (_cart == null)
                            _cart = new CartCollection();
                    }
                }
                return _cart;
            }

        }


    }
}
