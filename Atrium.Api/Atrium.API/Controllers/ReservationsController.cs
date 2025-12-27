using Microsoft.AspNetCore.Mvc;
using Atrium.Core.Interfaces;
using Atrium.Core.DTOs.Reservations;

namespace Atrium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDto>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDto>> CreateReservation(CreateReservationDto reservation)
        {
            var createdReservation = await _reservationService.CreateReservationAsync(reservation);

            return CreatedAtAction(
                nameof(GetReservationById),
                new {id = createdReservation.Id},
                createdReservation);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, UpdateReservationDto updateReservation)
        {
            await _reservationService.UpdateReservationAsync(id, updateReservation);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);

            return NoContent();
        }
    }
}
