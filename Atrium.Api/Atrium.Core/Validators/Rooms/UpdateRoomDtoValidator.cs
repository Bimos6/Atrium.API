using Atrium.Core.DTOs.Rooms;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateRoomDtoValidator : AbstractValidator<UpdateRoomDto>
    {
        public UpdateRoomDtoValidator()
        {
            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0).WithMessage("Тип комнаты должен быть больше 0")
                .When(x => x.RoomTypeId.HasValue);

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Отель должен быть больше 0")
                .When(x => x.HotelId.HasValue);

            RuleFor(x => x.RoomNumber)
                .MaximumLength(10).WithMessage("Номер комнаты не более 10 символов")
                .Matches(@"^[0-9A-Z\-]+$").WithMessage("Номер комнаты может содержать только цифры, буквы и дефис")
                .When(x => !string.IsNullOrEmpty(x.RoomNumber));

            RuleFor(x => x.Floor)
                .InclusiveBetween(1, 100).WithMessage("Этаж должен быть от 1 до 100")
                .When(x => x.Floor.HasValue);

            RuleFor(x => x.Status)
                .Must(BeAValidStatus).WithMessage("Неверный статус комнаты")
                .When(x => !string.IsNullOrEmpty(x.Status));

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Цена должна быть больше 0")
                .LessThan(1000000).WithMessage("Цена не может превышать 1,000,000")
                .When(x => x.Price.HasValue);

            RuleFor(x => x.MaxGuests)
                .InclusiveBetween(1, 10).WithMessage("Максимальное количество гостей должно быть от 1 до 10")
                .When(x => x.MaxGuests.HasValue);

            RuleFor(x => x)
                .Must(x => x.RoomTypeId.HasValue ||
                           x.HotelId.HasValue ||
                           !string.IsNullOrEmpty(x.RoomNumber) ||
                           x.Floor.HasValue ||
                           !string.IsNullOrEmpty(x.Status) ||
                           x.Price.HasValue ||
                           x.MaxGuests.HasValue)
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }

        private bool BeAValidStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return true;
            var validStatuses = new[] { "available", "occupied", "maintenance", "cleaning" };
            return validStatuses.Contains(status.ToLower());
        }
    }
}