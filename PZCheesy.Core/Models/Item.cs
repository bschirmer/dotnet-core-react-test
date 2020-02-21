using System;
using System.Collections.Generic;
using System.Text;

namespace PZCheesy.Core.Models
{
    public class Item
    {
        public string SKU { get; set; } //This is a unique identifier 
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
