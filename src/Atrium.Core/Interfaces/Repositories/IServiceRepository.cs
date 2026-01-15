using Atrium.Core.Models;

namespace Atrium.Core.Interfaces
{
    public interface IServiceRepository
    {
        public Task<List<Service>> GetAllAsync();
        public Task<Service> GetByIdAsync(int id);
        public Task<Service> CreateAsync(Service room);
        public Task UpdateAsync(int id, Service room);
        public Task DeleteAsync(int id);
    }
}
