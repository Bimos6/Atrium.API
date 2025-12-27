using Atrium.Core.DTOs.Hotels;

namespace Atrium.Core.Interfaces
{
    public interface IHotelService
    {
        Task<List<HotelDto>> GetAllHotelsAsync();
        Task<HotelDto> GetHotelByIdAsync(int id);
        Task<HotelDto> CreateHotelAsync(CreateHotelDto guest);
        Task UpdateHotelAsync(int id, UpdateHotelDto guest);
        Task DeleteHotelAsync(int id);
    }
}
