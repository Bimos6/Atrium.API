using Atrium.Core.DTOs.Reservations;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateReservationDtoValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationDtoValidator()
        {
            RuleFor(x => x.CheckInDate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Дата заезда не может быть в прошлом")
                .When(x => x.CheckInDate.HasValue);

            RuleFor(x => x.CheckOutDate)
                .GreaterThan(x => x.CheckInDate ?? DateTime.MinValue)
                .WithMessage("Дата выезда должна быть позже даты заезда")
                .When(x => x.CheckOutDate.HasValue && x.CheckInDate.HasValue);

            RuleFor(x => x.AdultsCount)
                .InclusiveBetween(1, 10).WithMessage("Количество взрослых должно быть от 1 до 10")
                .When(x => x.AdultsCount.HasValue);

            RuleFor(x => x.ChildrenCount)
                .InclusiveBetween(0, 10).WithMessage("Количество детей должно быть от 0 до 10")
                .When(x => x.ChildrenCount.HasValue);

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Общая сумма должна быть больше 0")
                .When(x => x.TotalAmount.HasValue);

            RuleFor(x => x.Status)
                .Must(BeAValidStatus).WithMessage("Неверный статус бронирования")
                .When(x => !string.IsNullOrEmpty(x.Status));

            RuleFor(x => x)
                .Must(x => x.CheckInDate.HasValue ||
                           x.CheckOutDate.HasValue ||
                           x.AdultsCount.HasValue ||
                           x.ChildrenCount.HasValue ||
                           x.TotalAmount.HasValue ||
                           !string.IsNullOrEmpty(x.Status))
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }

        private bool BeAValidStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return true;
            var validStatuses = new[] { "pending", "confirmed", "cancelled", "completed" };
            return validStatuses.Contains(status.ToLower());
        }
    }
}