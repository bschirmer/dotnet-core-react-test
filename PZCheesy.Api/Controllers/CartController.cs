using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("/cart/add")]
        public bool AddToCart([FromBody] Item item)
        {
            return cartService.AddToCart(item.SKU);
        }

        [HttpGet("/cart/count")]
        public int GetCartCount()
        {
            return cartService.GetCartItems().Count; 
        }

    }
}