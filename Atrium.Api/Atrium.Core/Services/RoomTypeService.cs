using Atrium.Core.DTOs.RoomTypes;
using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using AutoMapper;
using FluentValidation;

namespace Atrium.Core.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IValidator<CreateRoomTypeDto> _createValidator;
        private readonly IValidator<UpdateRoomTypeDto> _updateValidator;
        private readonly IMapper _mapper;

        public RoomTypeService(
            IRoomTypeRepository roomTypeRepository,
            IValidator<CreateRoomTypeDto> createValidator,
            IValidator<UpdateRoomTypeDto> updateValidator,
            IMapper mapper
            )
        {
            _roomTypeRepository = roomTypeRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<RoomTypeDto>> GetAllRoomTypesAsync()
        {
            var roomTypes = await _roomTypeRepository.GetAllAsync();
            return _mapper.Map<List<RoomTypeDto>>(roomTypes);
        }

        public async Task<RoomTypeDto> GetRoomTypeByIdAsync(int id)
        {
            var roomType = await _roomTypeRepository.GetByIdAsync(id);
            return _mapper.Map<RoomTypeDto>(roomType);
        }

        public async Task<RoomTypeDto> CreateRoomTypeAsync(CreateRoomTypeDto roomTypeDto)
        {
            await _createValidator.ValidateAndThrowAsync(roomTypeDto);
            var roomType = _mapper.Map<RoomType>(roomTypeDto);
            var createdRoomType = await _roomTypeRepository.CreateAsync(roomType);

            return _mapper.Map<RoomTypeDto>(createdRoomType);
        }

        public async Task UpdateRoomTypeAsync(int id, UpdateRoomTypeDto updateRoomTypeDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateRoomTypeDto);
            var roomType = await _roomTypeRepository.GetByIdAsync(id);
            _mapper.Map(updateRoomTypeDto, roomType);

            await _roomTypeRepository.UpdateAsync(id, roomType);
        }

        public async Task DeleteRoomTypeAsync(int id)
        {
            await _roomTypeRepository.DeleteAsync(id);
        }
    }
}
