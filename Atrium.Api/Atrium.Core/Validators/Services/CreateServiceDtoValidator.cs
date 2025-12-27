using Atrium.Core.DTOs.Services;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название услуги обязательно")
                .MaximumLength(50).WithMessage("Название не более 50 символов");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Описание услуги обязательно")
                .MaximumLength(200).WithMessage("Описание не более 200 символов");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Цена услуги обязательна")
                .GreaterThan(0).WithMessage("Цена услуги должна быть больше 0")
                .LessThan(100000).WithMessage("Цена услуги не может превышать 100,000");

            RuleFor(x => x.IsAvailable)
                .NotNull().WithMessage("Статус доступности обязателен");
        }
    }
}