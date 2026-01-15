using Atrium.Core.DTOs.Rooms;

namespace Atrium.Core.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(int id);
        Task<RoomDto> CreateRoomAsync(CreateRoomDto guest);
        Task UpdateRoomAsync(int id, UpdateRoomDto guest);
        Task DeleteRoomAsync(int id);
    }
}
