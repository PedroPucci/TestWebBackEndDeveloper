using TestWebBackEndDeveloper.Domain.Entity;
using FluentValidation;
using TestWebBackEndDeveloper.Shared.Enums.Errors;
using TestWebBackEndDeveloper.Shared.Helpers;

namespace TestWebBackEndDeveloper.Shared.Validator
{
    public class AccountUserRequestValidator : AbstractValidator<AccountUser>
    {
        public AccountUserRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage(AcountUserErrors.AccountUser_Error_NameCanNotBeNullOrEmpty.Description())
                .MinimumLength(4)
                    .WithMessage(AcountUserErrors.AccountUser_Error_NameLenghtLessFour.Description());

            RuleFor(p => p.Email)
                .NotEmpty()
                    .WithMessage(AcountUserErrors.AccountUser_Error_EmailCanNotBeNullOrEmpty.Description())
                .MinimumLength(4)
                    .WithMessage(AcountUserErrors.AccountUser_Error_EmailLenghtLessFour.Description())
                .EmailAddress()
                    .WithMessage(AcountUserErrors.AccountUser_Error_InvalidEmailFormat.Description());

            RuleFor(p => p.Password)
                .NotEmpty()
                    .WithMessage(AcountUserErrors.AccountUser_Error_PasswordCanNotBeNullOrEmpty.Description())
                .MinimumLength(6)
                    .WithMessage(AcountUserErrors.AccountUser_Error_PasswordLenghtLessFour.Description())
                .Matches(@"^(?=.*[A-Za-z]{4,})(?=.*\d{2,}).*$")
                    .WithMessage(AcountUserErrors.AccountUser_Error_PasswordInvalid.Description());
        }
    }
}