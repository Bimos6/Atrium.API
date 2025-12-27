using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using Atrium.Data;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllAsync() 
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task UpdateAsync(int id, Reservation updateReservation)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            reservation.GuestId = updateReservation.GuestId;
            reservation.RoomId = updateReservation.RoomId;
            reservation.CheckInDate = updateReservation.CheckInDate;
            reservation.CheckOutDate = updateReservation.CheckOutDate;
            reservation.AdultsCount = updateReservation.AdultsCount;
            reservation.ChildrenCount = updateReservation.ChildrenCount;
            reservation.TotalAmount = updateReservation.TotalAmount;
            reservation.Status = updateReservation.Status;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
