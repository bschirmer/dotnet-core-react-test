using PZCheesy.Core.Models;
using System.Collections.Generic;

namespace PZCheesy.Data
{
    /**
     *  As this is POC, the data is hardcoded
     *  For simplicity, the data will be kept in memory
     *  This would usually be where all database calls are done
     */
    public class CartData
    {
        public CartData() {
            this.cartItems = new List<Item>();
        }

        private List<Item> cartItems;
        public List<Item> GetCartItems() => cartItems;
        public void AddItemToCart(Item item)
        {
            cartItems.Add(item);
        }

        public bool RemoveItemFromCart(Item item)
        {
           return cartItems.Remove(item);
        }

        public void EmptyCart() { cartItems.Clear(); }

    }
}
