using System;

namespace SneakerApi.core
{
    class Program
    {
        static void Main(string[] args)
        {
        // --- LINQ --- //  
            List<SneakerRecord> catalog = new List<SneakerRecord>
            {
                new SneakerRecord("Nike", "Air Force 1", "White", 100.00m, true),
                new SneakerRecord("Nike", "Air Jordan 1", "Red", 180.00m, true),
                new SneakerRecord("Addas", "Yeezy 350", "Black", 250.00m, false),
                new SneakerRecord("Adidas", "Forum Low", "White", 95.00m, true),
                new SneakerRecord("New Balance", "550", "Grey", 120.00m, true)
            };

            System.Console.WriteLine("--- DEMO LINQ ---");

            var availableNikes = catalog
                .Where(s =>s.InStock && s.Brand == "Nike").ToList();

            System.Console.WriteLine("\n[1] Nike disponible en stock :");
            foreach(var sneaker in availableNikes)
            {
                System.Console.WriteLine($" - {sneaker.Model} : ${sneaker.Price} ");
            }

            var sortedByPrice = catalog
                .OrderBy(s => s.Price).ToList();

            System.Console.WriteLine("\n[n2] Catalogue trie par prix croissant :");
            foreach(var sneaker in sortedByPrice)
            {
                System.Console.WriteLine($" - {sneaker.Brand} {sneaker.Model} (${sneaker.Price})");
            }

            var upToOneHundred = catalog
                .Where(s =>s.InStock && s.Price > 100.00m)
                .ToList();
            
            System.Console.WriteLine("\n[3] Disponible en stock avec prix superieur a $100.00 :");
            foreach(var sneaker in upToOneHundred)
            {
                System.Console.WriteLine($" - {sneaker.Brand} {sneaker.Model} : ${sneaker.Price}");
            }
            System.Console.WriteLine();

            System.Console.WriteLine("--- DEMO PATTERN MATCHING ---");

            System.Console.WriteLine("\n[4] Details sur les status de produits :");
            foreach(SneakerRecord sneaker in catalog)
            {
                System.Console.WriteLine($" - {sneaker.Brand} {sneaker.Model} (${sneaker.Price}) -> {GetPriceCategory(sneaker)}");
            }
        }
        // --- Pattern Matching --- //
        static string GetPriceCategory(SneakerRecord sneaker) => sneaker switch
        {
            {InStock: false} => "❌ Indisponible",
            {Price: < 100.00m} => "🏷️ Économique",
            {Price: >= 100.00m and <= 200.00m} => "👟 Prix Standard",
            {Price: >200.00m} => "🔥 Édition Limitée / Premium",
            _ => "Categorie inconnue"
        };
    }

    public record SneakerRecord( string Brand, string Model, string Color, decimal Price, bool InStock);
}
