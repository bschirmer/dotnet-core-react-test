using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;
using System.Linq;

namespace PZCheesy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CheeseController : ControllerBase
    {
        private readonly ICheeseService _cheeseService;
        public CheeseController(ICheeseService cheeseService)
        {
            this._cheeseService = cheeseService;
        }

        [HttpGet("/cheese/all")]
        public IEnumerable<Cheese> GetAllCheese()
        {
            var cheese = _cheeseService.GetAllCheese();
            return cheese.ToArray();
        }

        [HttpPost("/cheese/getBySku")]
        public Cheese GetCheeseBySku([FromBody] Item item)
        {
            return _cheeseService.GetAllCheese().FirstOrDefault(x => x.SKU == item.SKU);
        }

    }
}