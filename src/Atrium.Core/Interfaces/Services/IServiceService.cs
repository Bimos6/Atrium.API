using Atrium.Core.DTOs.Services;

namespace Atrium.Core.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceDto>> GetAllServicesAsync();
        Task<ServiceDto> GetServiceByIdAsync(int id);
        Task<ServiceDto> CreateServiceAsync(CreateServiceDto guest);
        Task UpdateServiceAsync(int id, UpdateServiceDto guest);
        Task DeleteServiceAsync(int id);
    }
}
