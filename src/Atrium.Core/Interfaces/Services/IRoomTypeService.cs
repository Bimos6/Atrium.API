using Atrium.Core.DTOs.RoomTypes;


namespace Atrium.Core.Interfaces
{
    public interface IRoomTypeService
    {
        Task<List<RoomTypeDto>> GetAllRoomTypesAsync();
        Task<RoomTypeDto> GetRoomTypeByIdAsync(int id);
        Task<RoomTypeDto> CreateRoomTypeAsync(CreateRoomTypeDto roomType);
        Task UpdateRoomTypeAsync(int id, UpdateRoomTypeDto roomType);
        Task DeleteRoomTypeAsync(int id);
    }
}
