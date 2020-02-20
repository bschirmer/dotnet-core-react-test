using PZCheesy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PZCheesy.Core.Services
{
    public interface ICartService
    {
        bool AddToCart(int id);
        void RemoveFromCart(Cheese cheese);
        void UpdateQuantity(Cheese cheese, decimal quantity);

        List<Cheese> GetCartItems();
    }
}
