using Atrium.Core.DTOs.Hotels;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateHotelDtoValidator : AbstractValidator<UpdateHotelDto>
    {
        public UpdateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Название не более 100 символов")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Адрес не более 200 символов")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Телефон не более 20 символов")
                .Matches(@"^\+?[0-9\s\-\(\)]+$").WithMessage("Неверный формат телефона")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не более 100 символов")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Рейтинг должен быть от 0 до 5")
                .When(x => x.Rating.HasValue);

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Описание не более 500 символов")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Name) ||
                           !string.IsNullOrEmpty(x.Address) ||
                           !string.IsNullOrEmpty(x.Phone) ||
                           !string.IsNullOrEmpty(x.Email) ||
                           x.Rating.HasValue ||
                           !string.IsNullOrEmpty(x.Description))
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }
    }
}