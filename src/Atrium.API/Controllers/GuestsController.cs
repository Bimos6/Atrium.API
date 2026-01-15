using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.Guests;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GuestDto>>> GetAllGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();

            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);

            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> CreateGuest(CreateGuestDto guest)
        {
            var createdGuest = await _guestService.CreateGuestAsync(guest);

            return CreatedAtAction(
                nameof(GetGuestById),
                new { id = createdGuest.Id },
                createdGuest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(int id, UpdateGuestDto updateGuest)
        {
            await _guestService.UpdateGuestAsync(id, updateGuest);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            await _guestService.DeleteGuestAsync(id);

            return NoContent();
        }
    }
}
