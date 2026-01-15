using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using Atrium.Data;
using Microsoft.EntityFrameworkCore;

namespace Atrium.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Service> CreateAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return service;
        }

        public async Task UpdateAsync(int id, Service updateService)
        {
            var service = await _context.Services.FindAsync(id);

            service.Name = updateService.Name;
            service.Description = updateService.Description;
            service.Price = updateService.Price;
            service.IsAvailable = updateService.IsAvailable;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
