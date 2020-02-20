using PZCheesy.Core.Models;
using PZCheesy.Core.Services;
using PZCheesy.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PZCheesy.Services
{
    /**
     * This service is very basic and there is some double up in code,
     * but if there was a real database in place, this class would be used for service logic
     * and the data layer would be used to make database calls
     * 
     * Again, I could have prefered to have this Generic instead of Cheese, but for POC sake, this works
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
        public bool AddToCart(int id)
        {
            var cheese = CheeseData.GetAllCheese().FirstOrDefault(x => x.Id == id);

            if (cheese == null) return false;
            cartItems.AddItemToCart(cheese);
            return true;
        }

        public List<Cheese> GetCartItems()
        {
            return cartItems.GetCartItems();
        }

        public void RemoveFromCart(Cheese cheese)
        {
            cartItems.RemoveItemFromCart(cheese);
        }

        public void UpdateQuantity(Cheese cheese, decimal quantity)
        {
            var cartItem = cartItems.GetCartItems().FirstOrDefault(x => x.Id == cheese.Id);
            if (cartItem == null) return;

            cartItem.Quantity = quantity;

            // Remove old item
            cartItems.RemoveItemFromCart(cheese);

            // add the updated version
            // TODO  check if c# passes references or not
            cartItems.AddItemToCart(cartItem);
        }
    }
}
