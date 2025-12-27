using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.Rooms;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RoomDto>>> GetRoomById(int id)
        {
            var rooms = await _roomService.GetRoomByIdAsync(id);

            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> CreateRoom(CreateRoomDto room)
        {
            var createdRoom = await _roomService.CreateRoomAsync(room);

            return CreatedAtAction(
                nameof(GetRoomById),
                new {id = createdRoom.Id},
                createdRoom);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, UpdateRoomDto updateRoom)
        {
            await _roomService.UpdateRoomAsync(id, updateRoom);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);

            return NoContent();
        }
    }
}
