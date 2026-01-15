using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.Hotels;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);

            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelDto>> CreateHotel(CreateHotelDto hotel)
        {
            var createdHotel = await _hotelService.CreateHotelAsync(hotel);

            return CreatedAtAction(
                nameof(GetHotelById),
                new { id = createdHotel.Id },
                createdHotel);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateHotel(int id, UpdateHotelDto updateHotel)
        {
            await _hotelService.UpdateHotelAsync(id, updateHotel);

            return NoContent();
        } 


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);

            return NoContent();
        }
    }
}
