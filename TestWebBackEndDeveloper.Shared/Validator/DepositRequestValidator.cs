using FluentValidation;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Shared.Enums.Errors;
using TestWebBackEndDeveloper.Shared.Helpers;

namespace TestWebBackEndDeveloper.Shared.Validator
{
    public class DepositRequestValidator : AbstractValidator<Deposit>
    {
        public DepositRequestValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(DepositErrors.Deposit_Error_ValueCanNotBeNullOrEmpty.Description());
        }
    }
}