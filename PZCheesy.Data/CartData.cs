using PZCheesy.Core.Models;
using System.Collections.Generic;

namespace PZCheesy.Data
{
    /**
     *  As this is POC, the data is hardcoded
     *  For simplicity, the data will be kept in memory
     *  This would usually be where all database calls are done
     */
    public static class CartData
    {
        private static List<Item> cartItems = new List<Item>();
        public  static List<Item> GetCartItems() => cartItems;
        public  static int GetCartItemCount() => cartItems.Count;
        public static void AddItemToCart(Item item)
        {
            cartItems.Add(item);
        }

        public static bool RemoveItemFromCart(Item item)
        {
            return cartItems.Remove(item);
        }

        public static void EmptyCart() { cartItems.Clear(); }

    }
}
