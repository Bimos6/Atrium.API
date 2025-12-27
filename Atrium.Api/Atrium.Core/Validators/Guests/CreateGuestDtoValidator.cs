using Atrium.Core.DTOs.Guests;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class CreateGuestDtoValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Имя обязательно")
                .MaximumLength(50).WithMessage("Имя не более 50 символов");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Фамилия обязательна")
                .MaximumLength(50).WithMessage("Фамилия не более 50 символов");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не более 100 символов");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Телефон обязателен")
                .Length(11).WithMessage("Телефон должен содержать 11 цифр")
                .Matches(@"^[0-9]+$").WithMessage("Телефон должен содержать только цифры");

            RuleFor(x => x.PassportNumber)
                .NotEmpty().WithMessage("Номер паспорта обязателен")
                .MaximumLength(50).WithMessage("Номер паспорта не более 50 символов");

            RuleFor(x => x.DateOfBirth)
                .NotNull().WithMessage("Дата рождения обязательна")
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("Гость должен быть старше 18 лет")
                .GreaterThan(DateTime.Now.AddYears(-120)).WithMessage("Некорректная дата рождения");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Адрес обязателен")
                .MaximumLength(100).WithMessage("Адрес не более 100 символов");
        }
    }
}