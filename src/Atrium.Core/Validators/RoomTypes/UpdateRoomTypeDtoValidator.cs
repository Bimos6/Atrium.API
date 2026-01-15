using Atrium.Core.DTOs.RoomTypes;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateRoomTypeDtoValidator : AbstractValidator<UpdateRoomTypeDto>
    {
        public UpdateRoomTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Название не более 50 символов")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не более 200 символов")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.BasePrice)
                .GreaterThan(0).WithMessage("Базовая цена должна быть больше 0")
                .LessThan(1000000).WithMessage("Базовая цена не может превышать 1,000,000")
                .When(x => x.BasePrice.HasValue);

            RuleFor(x => x.Size)
                .GreaterThan(0).WithMessage("Размер комнаты должен быть больше 0")
                .LessThan(1000).WithMessage("Размер комнаты не может превышать 1000 м²")
                .When(x => x.Size.HasValue);

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Name) ||
                           !string.IsNullOrEmpty(x.Description) ||
                           x.BasePrice.HasValue ||
                           x.Size.HasValue)
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }
    }
}