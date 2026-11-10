using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SneakerApi.core.Data;
using SneakerApi.core.Models;

namespace SneakerApi.core
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("=== SEMAINES 5 & 6 : TEST EF CORE & CRUD ASYNCHRONE ===\n");

            using var context = new SneakerDbContext();

            // 1 & 2. CREATE (Insertion si la table est vide)
            System.Console.WriteLine("--> 1. Vérification de la base de données...");

            if (!await context.Sneakers.AnyAsync())
            {
                System.Console.WriteLine("--> 2. Insertion de nouvelles sneakers...");

                var sneaker1 = new Sneaker
                {
                    Brand = "Nike",
                    Model = "Air Max 90",
                    Color = "White/Red",
                    Price = 160.00m,
                    InStock = true
                };

                var sneaker2 = new Sneaker
                {
                    Brand = "Adidas",
                    Model = "Ultraboost 1.0",
                    Color = "Core Black",
                    Price = 190.00m,
                    InStock = true
                };

                await context.Sneakers.AddRangeAsync(sneaker1, sneaker2);
                await context.SaveChangesAsync();
                System.Console.WriteLine("✅ 2 sneakers insérées avec succès en base de données !\n");
            }
            else
            {
                System.Console.WriteLine("--> Des données existent déjà dans la base.\n");
            }

            // 3. READ (Lecture du catalogue complet)
            System.Console.WriteLine("--> 3. Lecture du catalogue complet (AsNoTracking) :");
            var catalog = await context.Sneakers.AsNoTracking().ToListAsync();

            foreach (var s in catalog)
            {
                System.Console.WriteLine($"   [ID {s.ID}] {s.Brand} {s.Model} ({s.Color}) - ${s.Price} | En stock: {s.InStock}");
            }

            // 4. READ AVEC FILTRE (LINQ)
            System.Console.WriteLine("\n--> 4. Recherche des sneakers de marque 'Nike' :");
            var Nikes = await context.Sneakers
                                     .AsNoTracking()
                                     .Where(s => s.Brand == "Nike")
                                     .ToListAsync();

            foreach (var n in Nikes)
            {
                System.Console.WriteLine($"   Found: {n.Model} à ${n.Price}");
            }

            // 5. UPDATE (Mise à jour de la sneaker ID 1)
            System.Console.WriteLine("\n--> 5. Mise à jour du prix de la sneaker ID 1 (Nike Air Max 90) :");
            var sneakerToUpdate = await context.Sneakers.FirstOrDefaultAsync(s => s.ID == 1);

            if (sneakerToUpdate != null)
            {
                System.Console.WriteLine($"   Prix actuel : ${sneakerToUpdate.Price}");
                sneakerToUpdate.Price = 140.00m;
                await context.SaveChangesAsync();
                System.Console.WriteLine($"   ✅ Nouveau prix enregistré : ${sneakerToUpdate.Price}");
            }

            // 6. DELETE (Suppression de la sneaker ID 2)
            System.Console.WriteLine("\n--> 6. Suppression de la sneaker ID 2 (Adidas Ultraboost) :");
            var sneakerToDelete = await context.Sneakers.FirstOrDefaultAsync(s => s.ID == 2);

            if (sneakerToDelete != null)
            {
                context.Sneakers.Remove(sneakerToDelete);
                await context.SaveChangesAsync();
                System.Console.WriteLine("   ✅ Sneaker ID 2 supprimée de la base de données !");
            }

            // 7. VERIFICATION FINALE
            System.Console.WriteLine("\n--> 7. État final du catalogue :");
            var finalCatalog = await context.Sneakers.AsNoTracking().ToListAsync();

            foreach (var s in finalCatalog)
            {
                System.Console.WriteLine($"   [ID {s.ID}] {s.Brand} {s.Model} - ${s.Price}");
            }
        }
    }
}