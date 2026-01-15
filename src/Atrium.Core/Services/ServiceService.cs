using Atrium.Core.DTOs.RoomTypes;
using Atrium.Core.DTOs.Services;
using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using AutoMapper;
using FluentValidation;

namespace Atrium.Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IValidator<CreateServiceDto> _createValidator;
        private readonly IValidator<UpdateServiceDto> _updateValidator;
        private readonly IMapper _mapper;

        public ServiceService(
            IServiceRepository serviceRepository,
            IValidator<CreateServiceDto> createValidator,
            IValidator<UpdateServiceDto> updateValidator,
            IMapper mapper
            )
        {
            _serviceRepository = serviceRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> GetAllServicesAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return _mapper.Map< List<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            return _mapper.Map<ServiceDto>(service);
        }

        public async Task<ServiceDto> CreateServiceAsync(CreateServiceDto serviceDto)
        {
            await _createValidator.ValidateAndThrowAsync(serviceDto);
            var service = _mapper.Map<Service>(serviceDto);
            var createdService = await _serviceRepository.CreateAsync(service);

            return _mapper.Map<ServiceDto>(createdService);
        }

        public async Task UpdateServiceAsync(int id, UpdateServiceDto updateServiceDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateServiceDto);
            var service = await _serviceRepository.GetByIdAsync(id);
            _mapper.Map(updateServiceDto, service);

            await _serviceRepository.UpdateAsync(id, service);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteAsync(id);
        }
    }
}
