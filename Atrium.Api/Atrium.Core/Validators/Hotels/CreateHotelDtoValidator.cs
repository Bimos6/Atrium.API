using Atrium.Core.DTOs.Hotels;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateHotelDtoValidator : AbstractValidator<CreateHotelDto>
    {
        public CreateHotelDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название отеля обязательно")
                .MaximumLength(100).WithMessage("Название не более 100 символов");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Адрес отеля обязателен")
                .MaximumLength(200).WithMessage("Адрес не более 200 символов");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Телефон обязателен")
                .MaximumLength(20).WithMessage("Телефон не более 20 символов")
                .Matches(@"^\+?[0-9\s\-\(\)]+$").WithMessage("Неверный формат телефона");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не более 100 символов");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Рейтинг должен быть от 0 до 5");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Описание не более 500 символов")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}