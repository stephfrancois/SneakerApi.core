using System;

namespace SneakerApi.core
{
    class Program
    {
        static void Main(string[] args)
        {
        // --- Étape 4 : Utilistion de la classe Sneaker --- //
        List<Sneaker> catalog = new List<Sneaker>();

        Sneaker sneaker1 = new Sneaker("Nike", "Air Force 1", "White", 100.00m, true);
        Sneaker sneaker2 = new Sneaker("Nike", "Air Jordan 1", "Red", 180.00m, true);
        Sneaker sneaker3 = new Sneaker("Adidas", "Yeezy boost", "White", 250.00m, false);
        Sneaker sneaker4 = new Sneaker("New Balance", "500", "Black", 120.00m, true);

        catalog.Add(sneaker1);
        catalog.Add(sneaker2);
        catalog.Add(sneaker3);
        catalog.Add(sneaker4);

        System.Console.WriteLine("---- CATALOGUE POO ---");
        System.Console.WriteLine("Nombre de produits : " + catalog.Count);
        System.Console.WriteLine();

        foreach(Sneaker item in catalog)
            {
                if (item.InStock)
                {
                    System.Console.WriteLine("Produit : " + item.Brand + " " + item. Model + " - " + item.Color + "| Prix : $" + item.Price);
                }
            }
        }
    }

    public class Sneaker
    {
        public string Brand;
        public string Model;
        public string Color;
        public decimal Price;
        public bool InStock;

        public Sneaker(string brand, string model, string color, decimal price, bool inStock)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Price = price;
            InStock = inStock;
        }
        

    }
}
