using Atrium.Core.Interfaces;
using AutoMapper;
using FluentValidation;
using Atrium.Core.Models;
using Atrium.Core.DTOs.Guests;

namespace Atrium.Core.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IValidator<CreateGuestDto> _createValidator;
        private readonly IValidator<UpdateGuestDto> _updateValidator;
        private readonly IMapper _mapper;

        public GuestService(
            IGuestRepository guestRepository,
            IValidator<CreateGuestDto> createValidator,
            IValidator<UpdateGuestDto> updateValidator,
            IMapper mapper
            )
        {
            _guestRepository = guestRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<GuestDto>> GetAllGuestsAsync() 
        {
            var guests = await _guestRepository.GetAllAsync();
            return _mapper.Map<List<GuestDto>>(guests);
        }

        public async Task<GuestDto> GetGuestByIdAsync(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            return _mapper.Map<GuestDto>(guest);
        }

        public async Task<GuestDto> CreateGuestAsync(CreateGuestDto guestDto)
        {
            await _createValidator.ValidateAndThrowAsync(guestDto);
            var guest = _mapper.Map<Guest>(guestDto);
            var createdGuest = await _guestRepository.CreateAsync(guest);

            return _mapper.Map<GuestDto>(createdGuest);
        }

        public async Task UpdateGuestAsync(int id, UpdateGuestDto updateGuestDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateGuestDto);
            var guest = await _guestRepository.GetByIdAsync(id);
            _mapper.Map(updateGuestDto, guest);

            await _guestRepository.UpdateAsync(id, guest);
        }

        public async Task DeleteGuestAsync(int id)
        {
            await _guestRepository.DeleteAsync(id);
        }
    }
}
