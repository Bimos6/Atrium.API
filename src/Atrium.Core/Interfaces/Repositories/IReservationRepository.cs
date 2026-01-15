using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation guest);
        Task UpdateAsync(int id, Reservation guest);
        Task DeleteAsync(int id);
    }
}
