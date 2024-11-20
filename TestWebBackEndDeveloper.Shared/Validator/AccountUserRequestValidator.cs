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
                .MinimumLength(4)
                .WithMessage(AcountUserErrors.AccountUser_Error_NameCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Email)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage(AcountUserErrors.AccountUser_Error_EmailCanNotBeNullOrEmpty.Description());
        }
    }
}