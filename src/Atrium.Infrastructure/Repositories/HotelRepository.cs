using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using Atrium.Data;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAllAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hotel> CreateAsync(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task UpdateAsync(int id, Hotel updateHotel)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            hotel.Name = updateHotel.Name;
            hotel.Address = updateHotel.Address;
            hotel.Phone = updateHotel.Phone;
            hotel.Email = updateHotel.Email;
            hotel.Rating = updateHotel.Rating;
            hotel.Description = updateHotel.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
