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
        private List<Item> cartItems;

        public CartService() {
            cartItems = CartData.GetCartItems();
        }
        /**
         * I wanted to add a better return type for these services,
         * something that had a response and message. But I'm unsure of what that looks like
         */
        public bool AddToCart(string sku)
        {
            // I would make this more generic for anythign more than a POC
            var cheese = CheeseData.GetAllCheese().FirstOrDefault(x => x.SKU == sku);
            if (cheese == null) return false;

            CartData.AddItemToCart(cheese);
            return true;
        }

        public List<Item> GetCartItems()
        {
            return CartData.GetCartItems();
        }

        public Item GetCartItem(string sku)
        {
            return CartData.GetCartItems().FirstOrDefault(x => x.SKU == sku);
        }

        public void RemoveFromCart(Item item)
        {
            CartData.RemoveItemFromCart(item);
        }

        public void UpdateQuantity(Item item, decimal quantity)
        {
            var cartItem = CartData.GetCartItems().FirstOrDefault(x => x.SKU == item.SKU);
            if (cartItem == null) return;

            cartItem.Quantity = quantity;
        }
    }
}
