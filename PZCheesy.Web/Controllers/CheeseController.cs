using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private readonly ICheeseService _cheeseService;
        public CheeseController(ICheeseService cheeseService)
        {
            this._cheeseService = cheeseService;
        }

        [HttpGet("all")]
        public IEnumerable<Cheese> GetAllCheeseAsync()
        {
            var cheese = _cheeseService.GetAllCheese();

            return cheese.ToArray();
        }

    }
}