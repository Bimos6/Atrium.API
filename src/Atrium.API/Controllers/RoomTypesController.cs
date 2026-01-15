using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.RoomTypes;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomTypeDto>>> GetRoomTypes()
        {
            var roomTypes = await _roomTypeService.GetAllRoomTypesAsync();

            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RoomTypeDto>>> GetRoomTypeById(int id)
        {
            var roomTypes = await _roomTypeService.GetRoomTypeByIdAsync(id);

            return Ok(roomTypes);
        }

        [HttpPost]
        public async Task<ActionResult<RoomTypeDto>> CreateRoomType(CreateRoomTypeDto roomType)
        {
            var createdRoomType = await _roomTypeService.CreateRoomTypeAsync(roomType);

            return CreatedAtAction(
                nameof(GetRoomTypeById),
                new { id = createdRoomType.Id },
                createdRoomType);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateRoomType(int id, UpdateRoomTypeDto updateRoomType)
        {
            await _roomTypeService.UpdateRoomTypeAsync(id, updateRoomType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoomType(int id)
        {
            await _roomTypeService.DeleteRoomTypeAsync(id);

            return NoContent();
        }
    }
}
