using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("/add")]
        public string AddToCart(string sku)
        {
            System.Console.WriteLine(sku);
            //var cheese = cartService.AddToCart();

            return sku;
        }

        [HttpGet("/count")]
        public int GetCartCount()
        {
            return 5; 
        }

    }
}