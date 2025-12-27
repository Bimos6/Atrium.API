using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using Atrium.Data;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Infrastructure.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private ApplicationDbContext _context;

        public RoomTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomType>> GetAllAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            return await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == id);
        }

        public async Task<RoomType> CreateAsync(RoomType roomType)
        {
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }

        public async Task UpdateAsync(int id, RoomType updateRoomType)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);

            roomType.Name = updateRoomType.Name;
            roomType.Description = updateRoomType.Description;
            roomType.BasePrice = updateRoomType.BasePrice;
            roomType.Size = updateRoomType.Size;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
        }
    }
}
