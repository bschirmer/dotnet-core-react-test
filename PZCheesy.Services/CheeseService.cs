using PZCheesy.Core.Models;
using PZCheesy.Core.Services;
using PZCheesy.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PZCheesy.Services
{
    public class CheeseService : ICheeseService
    {
        public CheeseService() { }

        public List<Cheese> GetAllCheese()
        {
            return CheeseData.GetAllCheese();
        }
    }
}
