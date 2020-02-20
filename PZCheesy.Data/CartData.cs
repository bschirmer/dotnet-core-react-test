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
            this.cartItems = new List<Cheese>();
        }

        private List<Cheese> cartItems;
        public List<Cheese> GetCartItems() => cartItems;
        public void AddItemToCart(Cheese cheese)
        {
            // Ultimately this would take an Item and not a Cheese
            cartItems.Add(cheese);
        }

        public bool RemoveItemFromCart(Cheese cheese)
        {
           return cartItems.Remove(cheese);
        }

        public void EmptyCart() { cartItems.Clear(); }

    }
}
