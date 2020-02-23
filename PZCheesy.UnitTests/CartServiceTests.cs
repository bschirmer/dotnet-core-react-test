using NUnit.Framework;
using PZCheesy.Core.Models;
using PZCheesy.Data;
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

            var item = new Item() 
            {
                Id = 1,
                SKU = "1",
                Quantity = 100
            };

            cartService.AddToCart(item);
            cartItems = cartService.GetCartItems();
            Assert.AreEqual(1, cartItems.Count);

            // because of static data, I have had to clean up after each test
            CartData.EmptyCart();
        }        
        
        [Test]
        public void RemoveFromCart_Should_Remove_Item_From_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            // Adding more than 1 item to test the correct item is removed
            var item1 = new Item()
            {
                Id = 1,
                SKU = "2",
                Quantity = 100
            };

            var item2 = new Item()
            {
                Id = 2,
                SKU = "2",
                Quantity = 100
            };

            cartService.AddToCart(item1);
            cartService.AddToCart(item2);
            cartItems = cartService.GetCartItems();

            Assert.AreEqual(2, cartItems.Count);

            cartService.RemoveFromCart(item1);
            cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 1);
            Assert.AreEqual(item2.Id, cartItems[0].Id);

            // because of static data, I have had to clean up after each test
            CartData.EmptyCart();
        }

        [Test]
        public void UpdateQuantity_Should_Update_Quantity_Of_Item_In_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            var item = new Item()
            {
                Id = 1,
                SKU = "3",
                Quantity = 100
            };

            cartService.AddToCart(item);
            cartItems = cartService.GetCartItems();

            Assert.AreEqual(1, cartItems.Count);

            item.Quantity = 50;
            cartService.UpdateQuantity(item);

            item = cartService.GetCartItem(item.Id);

            Assert.AreEqual(50, item.Quantity);

            // because of static data, I have had to clean up after each test
            CartData.EmptyCart();
        }

        [Test]
        public void GetCartItems_Should_Return_All_Items_In_Cart()
        {
            var cartService = new CartService();
            var cartItems = cartService.GetCartItems();

            Assert.IsTrue(cartItems.Count == 0);

            var item1 = new Item()
            {
                Id = 1,
                SKU = "3",
                Quantity = 100
            };

            var item2 = new Item()
            {
                Id = 2,
                SKU = "1",
                Quantity = 100
            };

            var item3 = new Item()
            {
                Id = 3,
                SKU = "3",
                Quantity = 100
            };

            cartService.AddToCart(item1);
            cartService.AddToCart(item2);
            cartService.AddToCart(item3);

            cartItems = cartService.GetCartItems();

            Assert.AreEqual(3, cartItems.Count);

            // because of static data, I have had to clean up after each test
            CartData.EmptyCart();
        }
    }
}