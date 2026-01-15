using Atrium.Core.DTOs.Rooms;
using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using AutoMapper;
using FluentValidation;

namespace Atrium.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IValidator<CreateRoomDto> _createValidator;
        private readonly IValidator<UpdateRoomDto> _updateValidator;
        private readonly IMapper _mapper;

        public RoomService(
            IRoomRepository roomRepository,
            IValidator<CreateRoomDto> createValidator,
            IValidator<UpdateRoomDto> updateValidator,
            IMapper mapper
            )
        {
            _roomRepository = roomRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetRoomByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> CreateRoomAsync(CreateRoomDto roomDto)
        {
            await _createValidator.ValidateAndThrowAsync(roomDto);
            var room = _mapper.Map<Room>(roomDto);
            var createdRoom = await _roomRepository.CreateAsync(room);

            return _mapper.Map<RoomDto>(createdRoom);
        }

        public async Task UpdateRoomAsync(int id, UpdateRoomDto updateRoomDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateRoomDto);
            var room = await _roomRepository.GetByIdAsync(id);
            _mapper.Map(updateRoomDto, room);

            await _roomRepository.UpdateAsync(id, room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteAsync(id);
        }
    }
}
