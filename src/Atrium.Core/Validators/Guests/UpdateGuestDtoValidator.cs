using Atrium.Core.DTOs.Guests;
using FluentValidation;

namespace Atrium.Core.Validators
{
    public class UpdateGuestDtoValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50).WithMessage("Имя не более 50 символов")
                .When(x => !string.IsNullOrEmpty(x.FirstName));

            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("Фамилия не более 50 символов")
                .When(x => !string.IsNullOrEmpty(x.LastName));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не более 100 символов")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .Length(11).WithMessage("Телефон должен содержать 11 цифр")
                .Matches(@"^[0-9]+$").WithMessage("Телефон должен содержать только цифры")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Address)
                .MaximumLength(100).WithMessage("Адрес не более 100 символов")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.FirstName) ||
                           !string.IsNullOrEmpty(x.LastName) ||
                           !string.IsNullOrEmpty(x.Email) ||
                           !string.IsNullOrEmpty(x.Phone) ||
                           !string.IsNullOrEmpty(x.Address))
                .WithMessage("Для обновления должно быть передано хотя бы одно поле");
        }
    }
}