using System;

namespace SneakerApi.core
{
    class Program
    {
        static void Main(string[] args)
        {
        // --- Encapsulation --- //            
            Sneaker sneaker1 = new Sneaker("Nike", "Air Force 1", "White", 100.00m, true);
            SneakerRecord record1 = new SneakerRecord("Adidas", "Yeezy 350", "Black", 220.00m, true);

            System.Console.WriteLine("--- TEST D'ENCAPSULATION ---");
            System.Console.WriteLine("Produit : " + sneaker1.Brand + " " + sneaker1.Model);
            System.Console.WriteLine("Prix actuel: $" + sneaker1.Price);

            sneaker1.ApplyDiscount(15.00m);
            sneaker1.Sell();
            System.Console.WriteLine("Prix apres rabais : $" + sneaker1.Price);

            System.Console.WriteLine();
            System.Console.WriteLine("--- TEST D'ENCAPSULATION AVEC RECORD ---");
            System.Console.WriteLine("Produit : " + record1.Brand + " - " + record1.Model);
            System.Console.WriteLine("Prix actuel : $" + record1.Price);

        }
    }



    public class Sneaker
    {
        public string Brand {get; init;}
        public string Model {get; init;}
        public string Color {get; init;}
        public decimal Price {get; private set;}
        public bool InStock {get; private set;}

        public Sneaker(string brand, string model, string color, decimal price, bool inStock)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Price = price;
            InStock = inStock;
        }       


        public void ApplyDiscount(decimal discountAmount)
        {
            if(discountAmount <= 0)
            {
                System.Console.WriteLine("Attention : Le montant du rabais doit être positif !");
                return;
            }

            if (Price - discountAmount < 0)
            {
                Console.WriteLine("Attention : Le prix ne peut pas devenir négatif !");
                return;
            }

            Price = Price - discountAmount;
        }

        public void Restock()
        {
            InStock = true;
        }

        public void Sell()
        {
            InStock = false;
            System.Console.WriteLine("Ce produit n'est plus en stock!");
        }
    }
    public record SneakerRecord( string Brand, string Model, string Color, decimal Price, bool InStock);
    
}
