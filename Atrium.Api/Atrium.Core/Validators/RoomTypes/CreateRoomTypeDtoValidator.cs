using Atrium.Core.DTOs.RoomTypes;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateRoomTypeDtoValidator : AbstractValidator<CreateRoomTypeDto>
    {
        public CreateRoomTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название типа обязательно")
                .MaximumLength(50).WithMessage("Название не более 50 символов");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Описание обязательно")
                .MaximumLength(200).WithMessage("Описание не более 200 символов");

            RuleFor(x => x.BasePrice)
                .NotEmpty().WithMessage("Базовая цена обязательна")
                .GreaterThan(0).WithMessage("Базовая цена должна быть больше 0")
                .LessThan(1000000).WithMessage("Базовая цена не может превышать 1,000,000");

            RuleFor(x => x.Size)
                .NotEmpty().WithMessage("Размер комнаты обязателен")
                .GreaterThan(0).WithMessage("Размер комнаты должен быть больше 0")
                .LessThan(1000).WithMessage("Размер комнаты не может превышать 1000 м²");
        }
    }
}