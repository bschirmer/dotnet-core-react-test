using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZCheesy.Api.Resources;
using PZCheesy.Core.Models;
using PZCheesy.Core.Services;

namespace PZCheesy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private readonly ICheeseService _cheeseService;
        private readonly IMapper _mapper;
        public CheeseController(ICheeseService cheeseService)
        {
            this._cheeseService = cheeseService;
        }

        [HttpGet("")]
        public IEnumerable<Cheese> GetAllCheeseAsync()
        {
            var cheese = _cheeseService.GetAllCheese();

            return cheese;
        }

    }
}