using Atrium.Data;
using Atrium.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Atrium.Core.Models;

namespace Atrium.Infrastructure.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guest>> GetAllAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Guest> CreateAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return guest;
        }

        public async Task UpdateAsync(int id, Guest updateGuest) 
        {
            var guest = await _context.Guests.FindAsync(id);

            guest.FirstName = updateGuest.FirstName;
            guest.LastName = updateGuest.LastName;
            guest.Email = updateGuest.Email;
            guest.Phone = updateGuest.Phone;
            guest.PassportNumber = updateGuest.PassportNumber;
            guest.DateOfBirth = updateGuest.DateOfBirth;
            guest.Address = guest.Address;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }
    }
}
