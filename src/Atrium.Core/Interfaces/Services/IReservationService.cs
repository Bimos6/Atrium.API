using Atrium.Core.DTOs.Reservations;

namespace Atrium.Core.Interfaces
{
    public interface IReservationService
    {
        Task<List<ReservationDto>> GetAllReservationsAsync();
        Task<ReservationDto> GetReservationByIdAsync(int id);
        Task<ReservationDto> CreateReservationAsync(CreateReservationDto guest);
        Task UpdateReservationAsync(int id, UpdateReservationDto guest);
        Task DeleteReservationAsync(int id);
    }
}
