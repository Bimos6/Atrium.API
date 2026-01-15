using Atrium.Core.DTOs.Guests;

namespace Atrium.Core.Interfaces
{
    public interface IGuestService
    {
        Task<List<GuestDto>> GetAllGuestsAsync();
        Task<GuestDto> GetGuestByIdAsync(int id);
        Task<GuestDto> CreateGuestAsync(CreateGuestDto guest);
        Task UpdateGuestAsync(int id, UpdateGuestDto guest);
        Task DeleteGuestAsync(int id);
    }
}
