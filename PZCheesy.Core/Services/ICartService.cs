using PZCheesy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PZCheesy.Core.Services
{
    public interface ICartService
    {
        bool AddToCart(Item item);
        bool RemoveFromCart(Item item);
        Item UpdateQuantity(Item item);
        List<Cheese> GetCartItems(); // This would be more generic in real app
        Item GetCartItem(int id);
    }
}
