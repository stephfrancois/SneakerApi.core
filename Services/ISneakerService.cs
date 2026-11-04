using SneakerApi.core.Models;

namespace SneakerApi.core.Services
{
    public interface ISneakerService
    {
        Task<List<SneakerRecord>> GetAllAsync();
        Task<SneakerRecord> GetByIdAsync(int id);
    }
}