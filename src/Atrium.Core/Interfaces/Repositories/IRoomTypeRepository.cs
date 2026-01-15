using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IRoomTypeRepository
    {
        public Task<List<RoomType>> GetAllAsync();
        public Task<RoomType> GetByIdAsync(int id);
        public Task<RoomType> CreateAsync(RoomType roomType);
        public Task UpdateAsync(int id, RoomType roomType);
        public Task DeleteAsync(int id);
    }
}
