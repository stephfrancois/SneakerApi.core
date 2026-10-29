using System;
using System.Security.Cryptography.X509Certificates;

namespace SneakerApi.core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
        List<SneakerRecord> catalog = new List<SneakerRecord>
        {
            new SneakerRecord(1, "Nike", "Air Force 1", "White", 100.00m, true),
            new SneakerRecord(2, "Nike", "Air Jordan 1", "Red", 180.00m, true),
            new SneakerRecord(5, "Adidas", "Yeezy 350", "Black", 250.00m, false),
        };

        System.Console.WriteLine("--- DEMO ASYNC & EXEPTIONS ---");

        System.Console.WriteLine("Chargement du produit depuis la Base de donnees...");

            try
            {
                SneakerRecord sneaker = await FetchSneakerByIdAsync(catalog, 1);
                System.Console.WriteLine($"✅ Produit trouver : {sneaker.Brand} {sneaker.Model} (${sneaker.Price})");

                System.Console.WriteLine("\nRecherche d'un produit inexistant (ID 99)...");
                SneakerRecord notFoundSneaker = await FetchSneakerByIdAsync(catalog, 99);
            }

            catch(KeyNotFoundException ex)
            {
                System.Console.WriteLine($"⚠️ Erreur attrapée : {ex.Message}");
            }

            catch(Exception ex)
            {
                System.Console.WriteLine($"💥 Erreur innatendue : {ex.Message}");
            }

        System.Console.WriteLine("\nTest de la methode ProcessPaymentAsync...!!!");

            try
            {
                await ProcessPaymentAsync(100.00m);
                                
                await ProcessPaymentAsync(-50.00m);
            }

            catch(ArgumentException ex)
            {
                System.Console.WriteLine($"⚠️ Erreur de paiement : {ex.Message}");
            }

            catch(Exception ex)
            {
                System.Console.WriteLine($"💥 Erreur inattendue : {ex.Message}");
            }

        }

        
        public static async Task<SneakerRecord> FetchSneakerByIdAsync(List<SneakerRecord> catalog, int id)
        {
            await Task.Delay(1000);

            var sneaker = catalog.FirstOrDefault(s => s.Id == id);

            if(sneaker == null)
            {
                throw new KeyNotFoundException($"La sneaker avec l'ID {id} n'existe pas dans la catalogue.");
            }

            return sneaker;
        }

        public static async Task ProcessPaymentAsync(decimal amount)
        {
            await Task.Delay(1500);

            if(amount <= 0)
            {
                throw new ArgumentException("Le montant du paiement doit être supérieur à $0.00.");
            }
            Console.WriteLine($"Paiement de ${amount} effectué avec succès!");              
        }
    }
    public record SneakerRecord( int Id, string Brand, string Model, string Color, decimal Price, bool InStock);
}
