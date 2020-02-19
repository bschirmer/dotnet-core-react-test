using PZCheesy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PZCheesy.Core.Services
{
    public interface ICheeseService
    {
        Task<IEnumerable<Cheese>> GetAllCheeseAsync();

    }
}
