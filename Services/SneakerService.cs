using SneakerApi.core.Models;

namespace SneakerApi.core.Services
{
    public class SneakerService: ISneakerService
    {
        private readonly List<SneakerRecord> _catalog = new()
        {
            new SneakerRecord(1, "Nike", "Air Force 1", "White", 100.00m, true),
            new SneakerRecord(2, "Nike", "Air Jordan 1", "Red", 180.00m, true),
            new SneakerRecord(3, "Adidas", "Yeezy 350", "Black", 250.00m, false),
        };

        public async Task<List<SneakerRecord>> GetAllAsync()
        {
            await Task.Delay(500);
            return _catalog;
        }

        public async Task<SneakerRecord> GetByIdAsync(int id)
        {
            await Task.Delay(500);
            var sneaker = _catalog.FirstOrDefault(s => s.Id == id);

            if (sneaker == null)
            {
                throw new KeyNotFoundException($"La sneaker avec l'ID {id} n'existe pas.");
            
            } return sneaker;
        }
    }
}