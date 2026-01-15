using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.Services;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> GetAllServices()
        {
            var services = await _serviceService.GetAllServicesAsync();

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> CreateService(CreateServiceDto service)
        {
            var createdService = await _serviceService.CreateServiceAsync(service);

            return CreatedAtAction(
                nameof(GetServiceById),
                new {id=createdService.Id},
                createdService);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateService(int id, UpdateServiceDto updateService)
        {
            await _serviceService.UpdateServiceAsync(id, updateService);

            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);

            return NoContent();
        }
    }
}
