using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetAllAsync();
        Task<Guest> GetByIdAsync(int id);
        Task<Guest> CreateAsync(Guest guest);
        Task UpdateAsync(int id, Guest guest);
        Task DeleteAsync(int id);
    }
}
