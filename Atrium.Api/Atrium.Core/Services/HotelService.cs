using Atrium.Core.DTOs.Hotels;
using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using AutoMapper;
using FluentValidation;

namespace Atrium.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IValidator<CreateHotelDto> _createValidator;
        private readonly IValidator<UpdateHotelDto> _updateValidator;
        private readonly IMapper _mapper;

        public HotelService(
            IHotelRepository hotelRepository,
            IValidator<CreateHotelDto> createValidator,
            IValidator<UpdateHotelDto> updateValidator,
            IMapper mapper
            )
        {
            _hotelRepository = hotelRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<HotelDto>> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            return _mapper.Map<List<HotelDto>>(hotels);
        }

        public async Task<HotelDto> GetHotelByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<HotelDto> CreateHotelAsync(CreateHotelDto hotelDto)
        {
            await _createValidator.ValidateAndThrowAsync(hotelDto);
            var hotel = _mapper.Map<Hotel>(hotelDto);
            var createdHotel = await _hotelRepository.CreateAsync(hotel);

            return _mapper.Map<HotelDto>(createdHotel);
        }

        public async Task UpdateHotelAsync(int id, UpdateHotelDto updateHotelDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateHotelDto);
            var hotel = await _hotelRepository.GetByIdAsync(id);
            _mapper.Map(updateHotelDto, hotel);

            await _hotelRepository.UpdateAsync(id, hotel);
        }

        public async Task DeleteHotelAsync(int id)
        {
            await _hotelRepository.DeleteAsync(id);
        }
    }
}
