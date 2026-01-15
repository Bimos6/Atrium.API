using Atrium.Core.DTOs.Reservations;
using Atrium.Core.Interfaces;
using Atrium.Core.Models;
using AutoMapper;
using FluentValidation;

namespace Atrium.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IValidator<CreateReservationDto> _createValidator;
        private readonly IValidator<UpdateReservationDto> _updateValidator;
        private readonly IMapper _mapper;

        public ReservationService(
            IReservationRepository reservationRepository,
            IValidator<CreateReservationDto> createValidator,
            IValidator<UpdateReservationDto> updateValidator,
            IMapper mapper
            )
        {
            _reservationRepository = reservationRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        public async Task<List<ReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return _mapper.Map<List<ReservationDto>>(reservations);
        }

        public async Task<ReservationDto> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public async Task<ReservationDto> CreateReservationAsync(CreateReservationDto reservationDto)
        {
            await _createValidator.ValidateAndThrowAsync(reservationDto);
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var createdReservation = await _reservationRepository.CreateAsync(reservation);

            return _mapper.Map<ReservationDto>(createdReservation);
        }

        public async Task UpdateReservationAsync(int id, UpdateReservationDto updateReservationDto)
        {
            await _updateValidator.ValidateAndThrowAsync(updateReservationDto);
            var reservation = await _reservationRepository.GetByIdAsync(id);
            _mapper.Map(updateReservationDto, reservation);

            await _reservationRepository.UpdateAsync(id, reservation);
        }

        public async Task DeleteReservationAsync(int id)
        {
            await _reservationRepository.DeleteAsync(id);
        }
    }
}
