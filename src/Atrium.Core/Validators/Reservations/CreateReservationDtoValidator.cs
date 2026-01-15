using Atrium.Core.DTOs.Reservations;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateReservationDtoValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationDtoValidator()
        {
            RuleFor(x => x.GuestId)
                .GreaterThan(0).WithMessage("ID гостя обязательно");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("ID комнаты обязательно");

            RuleFor(x => x.CheckInDate)
                .NotEmpty().WithMessage("Дата заезда обязательна")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Дата заезда не может быть в прошлом");

            RuleFor(x => x.CheckOutDate)
                .NotEmpty().WithMessage("Дата выезда обязательна")
                .GreaterThan(x => x.CheckInDate).WithMessage("Дата выезда должна быть позже даты заезда");

            RuleFor(x => x)
                .Must(x => (x.CheckOutDate - x.CheckInDate).TotalDays >= 1)
                .WithMessage("Минимальная длительность проживания - 1 день");

            RuleFor(x => x)
                .Must(x => (x.CheckOutDate - x.CheckInDate).TotalDays <= 30)
                .WithMessage("Максимальная длительность проживания - 30 дней");

            RuleFor(x => x.AdultsCount)
                .NotEmpty().WithMessage("Количество взрослых обязательно")
                .InclusiveBetween(1, 10).WithMessage("Количество взрослых должно быть от 1 до 10");

            RuleFor(x => x.ChildrenCount)
                .InclusiveBetween(0, 10).WithMessage("Количество детей должно быть от 0 до 10");

            RuleFor(x => x.TotalAmount)
                .NotEmpty().WithMessage("Общая сумма обязательна")
                .GreaterThan(0).WithMessage("Общая сумма должна быть больше 0");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Статус обязателен")
                .Must(BeAValidStatus).WithMessage("Неверный статус бронирования");
        }

        private bool BeAValidStatus(string status)
        {
            var validStatuses = new[] { "pending", "confirmed", "cancelled", "completed" };
            return validStatuses.Contains(status.ToLower());
        }
    }
}