using System;
using System.Collections.Generic;
using System.Text;

namespace PZCheesy.Core.Models
{
    public class Cart
    {
        /**
         * In a real store, this would be filled with everything a cart need
         * Things I would add include user tracking like session data, 
         * 
         * NB: I wanted to make this generic but got stuck and didnt want to waste too much time on it.
         * I would have liked to have a list of Items and the Items model to be generic so any item could be used
         */
        public List<Cheese> Items { get; set; }

    }
}
