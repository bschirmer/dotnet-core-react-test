using System;
using System.Collections.Generic;
using System.Text;

namespace PZCheesy.Core.Models
{
    public class Item
    {
        public int Id { get; set; } //This is a unique identifier per item
        public string SKU { get; set; } //This is a unique identifier per product
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
