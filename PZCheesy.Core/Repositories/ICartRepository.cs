using PZCheesy.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PZCheesy.Core.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        /**
         *  Not sure i need this just yet
         *  This is for specific cart database functions
         */
        Task AddToCart();
        Task RemoveFromCart();
        Task UpdateQuantity();

    }
}
