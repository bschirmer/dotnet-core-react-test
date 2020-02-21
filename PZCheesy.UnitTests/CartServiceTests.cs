using NUnit.Framework;
using PZCheesy.Core.Models;
using PZCheesy.Services;

namespace PZCheesy.UnitTests
{
    [TestFixture]
    public class CartServiceTests
    {
        [Test]
        public void AddToCart_Should_Add_Item_To_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            var item = new Item();

            cartService.AddToCart(item);

            Assert.AreEqual(1, cartItems.Count);
        }        
        
        [Test]
        public void RemoveFromCart_Should_Remove_Item_From_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            var item = new Item();

            cartService.AddToCart(item);

            Assert.AreEqual(1, cartItems.Count);

            cartService.RemoveFromCart(item);

            Assert.IsTrue(cartItems.Count == 0);
        }

        [Test]
        public void UpdateQuantity_Should_Update_Quantity_Of_Item_In_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            var item = new Item()
            {
                SKU = "amazing_cheese",
                Quantity = 100
            };

            cartService.AddToCart(item);

            Assert.AreEqual(1, cartItems.Count);

            cartService.UpdateQuantity(item, 50);

            item = cartService.GetCartItem(item.SKU);

            Assert.AreEqual(50, item.Quantity);
        }
    }
}