using Atrium.Core.DTOs.Rooms;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateRoomDtoValidator : AbstractValidator<CreateRoomDto>
    {
        public CreateRoomDtoValidator()
        {
            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0).WithMessage("Тип комнаты обязателен");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Отель обязателен");

            RuleFor(x => x.RoomNumber)
                .NotEmpty().WithMessage("Номер комнаты обязателен")
                .MaximumLength(10).WithMessage("Номер комнаты не более 10 символов")
                .Matches(@"^[0-9A-Z\-]+$").WithMessage("Номер комнаты может содержать только цифры, буквы и дефис");

            RuleFor(x => x.Floor)
                .NotEmpty().WithMessage("Этаж обязателен")
                .InclusiveBetween(1, 100).WithMessage("Этаж должен быть от 1 до 100");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Статус обязателен")
                .Must(BeAValidStatus).WithMessage("Неверный статус комнаты");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Цена обязательна")
                .GreaterThan(0).WithMessage("Цена должна быть больше 0")
                .LessThan(1000000).WithMessage("Цена не может превышать 1,000,000");

            RuleFor(x => x.MaxGuests)
                .NotEmpty().WithMessage("Максимальное количество гостей обязательно")
                .InclusiveBetween(1, 10).WithMessage("Максимальное количество гостей должно быть от 1 до 10");
        }

        private bool BeAValidStatus(string status)
        {
            var validStatuses = new[] { "available", "occupied", "maintenance", "cleaning" };
            return validStatuses.Contains(status.ToLower());
        }
    }
}