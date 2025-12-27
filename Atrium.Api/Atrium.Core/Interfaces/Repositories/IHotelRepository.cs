using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task<Hotel> CreateAsync(Hotel guest);
        Task UpdateAsync(int id, Hotel guest);
        Task DeleteAsync(int id);
    }
}
