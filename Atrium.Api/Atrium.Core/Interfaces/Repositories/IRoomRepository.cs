using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetAllAsync();
        public Task<Room> GetByIdAsync(int id);
        public Task<Room> CreateAsync(Room room);
        public Task UpdateAsync(int id, Room room);
        public Task DeleteAsync(int id);
    }
}
