using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private readonly ICheeseService _cheeseService;
        public CheeseController(ICheeseService cheeseService)
        {
            this._cheeseService = cheeseService;
        }

        [HttpGet("/all")]
        public IEnumerable<Cheese> GetAllCheese()
        {
            var cheese = _cheeseService.GetAllCheese();
            return cheese.ToArray();
        }

    }
}