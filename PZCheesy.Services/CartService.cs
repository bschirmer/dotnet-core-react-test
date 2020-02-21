using PZCheesy.Core.Models;
using PZCheesy.Core.Services;
using PZCheesy.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PZCheesy.Services
{
    /**
     * This service is very basic and there is some double up in code with the data layer,
     * but if there was a real database in place, this class would be used for service logic
     * and the data layer would be used to make database calls
     */
    public class CartService : ICartService
    {
        private CartData cartItems;

        public CartService() {
            cartItems = new CartData();
        }
        /**
         * I wanted to add a better return type for these services,
         * something that had a response and message. But I'm unsure of what that looks like
         */
        public void AddToCart(Item item)
        {
            Console.WriteLine(item.SKU);
            cartItems.AddItemToCart(item);
        }

        public List<Item> GetCartItems()
        {
            return cartItems.GetCartItems();
        }

        public Item GetCartItem(string sku)
        {
            return cartItems.GetCartItems().FirstOrDefault(x => x.SKU == sku);
        }

        public void RemoveFromCart(Item item)
        {
            cartItems.RemoveItemFromCart(item);
        }

        public void UpdateQuantity(Item item, decimal quantity)
        {
            var cartItem = cartItems.GetCartItems().FirstOrDefault(x => x.SKU == item.SKU);
            if (cartItem == null) return;

            cartItem.Quantity = quantity;
        }
    }
}
