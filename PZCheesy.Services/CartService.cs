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

        public bool AddToCart(Item item)
        {
            // I would make this more generic for anything more than a POC

            var cheese = CheeseData.GetAllCheese().FirstOrDefault(x => x.SKU == item.SKU);
            if (cheese == null) return false;

            // Because of static Cheese data, this copy is needed to give the illution of more than 1 item. This would not be the case in a real app.
            // This felt dirty, I had to shower after this.
            var cartItem = new Cheese()
            {
                Name = cheese.Name,
                Colour = cheese.Colour,
                Flavour = cheese.Flavour,
                Aroma = cheese.Aroma,
                PictureRef = cheese.PictureRef,
                SKU = cheese.SKU,
                Texture = cheese.Texture,
                Price = cheese.Price,
                Quantity = item.Quantity,
                Id = CartData.GetCartItemCount() + 1
        };

            CartData.AddItemToCart(cartItem);
            return true;
        }

        public List<Cheese> GetCartItems()
        {
            var cartItems = CartData.GetCartItems();
            var returnList = new List<Cheese>();
            foreach(var cartItem in cartItems)
            {
                var cheese = CheeseData.GetAllCheese().FirstOrDefault(x => x.SKU == cartItem.SKU);
                if (cheese == null) continue;
                returnList.Add(new Cheese()
                {
                    Name = cheese.Name,
                    Aroma = cheese.Aroma,
                    Colour = cheese.Colour,
                    Flavour = cheese.Flavour,
                    PictureRef = cheese.PictureRef,
                    Price = cheese.Price,
                    SKU = cheese.SKU,
                    Texture = cheese.Texture,

                    Id = cartItem.Id,
                    Quantity = cartItem.Quantity
                });
            }
            return returnList;
        }

        public Item GetCartItem(int id)
        {
            return CartData.GetCartItems().FirstOrDefault(x => x.Id == id);
        }

        public void RemoveFromCart(Item item)
        {
            var cartItem = CartData.GetCartItems().FirstOrDefault(x => x.Id == item.Id);
            CartData.RemoveItemFromCart(cartItem);
        }

        public Item UpdateQuantity(Item item)
        {
            var cartItem = CartData.GetCartItems().FirstOrDefault(x => x.Id == item.Id);
            if (cartItem == null) return null;

            cartItem.Quantity = item.Quantity;

            return cartItem;
        }
    }
}
