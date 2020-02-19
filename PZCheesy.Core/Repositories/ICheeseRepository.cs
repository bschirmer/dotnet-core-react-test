using PZCheesy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PZCheesy.Core.Repositories
{
    public interface ICheeseRepository : IRepository<Cheese>
    {
        /**
         *  Not sure i need this just yet
         *  This is for specific cheese database functions
         */
        Task<IEnumerable<Cheese>> GetAllCheeseAsync();

    }
}
