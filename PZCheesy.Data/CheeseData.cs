using PZCheesy.Core.Models;
using System.Collections.Generic;

namespace PZCheesy.Data
{
    /**
     *  As this is POC, the data is hardcoded
     *  This would usually be where all database calls are done
     */
    public static class CheeseData
    {
        private static Cheese _cheese1 = new Cheese() { 
            Id = 1, 
            Name = "Halloumi", 
            Colour = "White",
            Texture = "Chewy, Creamy, Firm and Springy",
            Flavour = "Salty, Savory, Tangy",
            Aroma = "Strong",
            Price = 31.01M, 
            PictureRef = "https://healthyrecipesblogs.com/wp-content/uploads/2011/05/grilled-halloumi-1.jpg" };

        private static Cheese _cheese2 = new Cheese()
        {
            Id = 2,
            Name = "Provolone",
            Colour = "Pale Yellow",
            Texture = "Firm, Grainy and Open",
            Flavour = "Buttery, Mild, Sharp, Spicy, Sweet, Tangy",
            Aroma = "Pleasant",
            Price = 7.27M,
            PictureRef = "https://cdn.tridge.com/image/original/7f/df/f8/7fdff890e9a9a26bdc03368b60324e54e5527da9.jpg"
        };

        private static Cheese _cheese3 = new Cheese()
        {
            Id = 3,
            Name = "Blue Vein",
            Colour = "Blue",
            Texture = "Creamy",
            Flavour = "Salty, Sharp, Tangy",
            Aroma = "Stinky, Strong",
            Price = 33.50M,
            PictureRef = "https://3.imimg.com/data3/UB/LL/MY-3052025/blue-cheese-danish-range-250x250.jpg"
        };

        private static Cheese _cheese4 = new Cheese()
        {
            Id = 4,
            Name = "Fromage A Raclette",
            Colour = "Pale Yellow",
            Texture = "Creamy, Firm, Open and Smooth",
            Flavour = "Acidic, Milky, Nutty, Sweet",
            Aroma = "Aromatic, Fruity, Pleasant",
            Price = 64.90M,
            PictureRef = "https://cdn.shopify.com/s/files/1/0063/4683/4031/products/raclette.jpg?v=1548178785"
        };

        private static Cheese _cheese5 = new Cheese()
        {
            Id = 5,
            Name = "Red Leicester",
            Colour = "Orange",
            Texture = "Crumbly and Dense",
            Flavour = "Burnt Caramel, Full-Flavored, Sweet",
            Aroma = "Rich",
            Price = 24.99M,
            PictureRef = "https://www.igourmet.com/images/products/red_leicester_taw_valley.jpg"
        };

        private static List<Cheese> AllCheese = new List<Cheese>() { _cheese1, _cheese2, _cheese3, _cheese4, _cheese5 };

        public static List<Cheese> GetAllCheese() => AllCheese;
    }
}
