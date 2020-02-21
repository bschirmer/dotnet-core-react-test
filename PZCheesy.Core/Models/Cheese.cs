using System;
using System.Collections.Generic;
using System.Text;

namespace PZCheesy.Core.Models
{
    public class Cheese : Item
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Flavour { get; set; }
        public string Texture { get; set; }
        public string Aroma { get; set; }
        public string PictureRef { get; set; }
    }
}
