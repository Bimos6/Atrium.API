using Atrium.Core.DTOs.Services;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("Название не более 50 символов")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не более 200 символов")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Цена услуги должна быть больше 0")
                .LessThan(100000).WithMessage("Цена услуги не может превышать 100,000")
                .When(x => x.Price.HasValue);

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Name) ||
                           !string.IsNullOrEmpty(x.Description) ||
                           x.Price.HasValue ||
                           x.IsAvailable.HasValue)
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }
    }
}