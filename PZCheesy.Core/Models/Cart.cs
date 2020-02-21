using System;
using System.Collections.Generic;
using System.Text;

namespace PZCheesy.Core.Models
{
    public class Cart
    {
        /**
         * In a real store, this would be filled with everything a cart need
         */
        public List<Item> Items { get; set; }

    }
}
