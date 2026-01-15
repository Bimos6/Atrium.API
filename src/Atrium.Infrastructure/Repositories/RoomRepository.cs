using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using Atrium.Data;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Room> CreateAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task UpdateAsync(int id, Room updateRoom)
        {
            var room = await _context.Rooms.FindAsync(id);

            room.HotelId = updateRoom.HotelId;
            room.RoomNumber = updateRoom.RoomNumber;
            room.Floor = updateRoom.Floor;
            room.Status = updateRoom.Status;
            room.Price = updateRoom.Price;
            room.MaxGuests = updateRoom.MaxGuests;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
