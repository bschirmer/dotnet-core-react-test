using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        //[HttpGet("/add/{id}")]
        //public void AddToCart()
        //{
        //    var cheese = cartService.AddToCart();

        //    return cheese.ToArray();
        //}

        [HttpGet("/cart/count")]
        public int GetCartCount()
        {
            return cartService.GetCartItems().Count; 
        }

    }
}