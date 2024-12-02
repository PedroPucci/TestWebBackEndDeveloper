using FluentValidation;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Shared.Enums.Errors;
using TestWebBackEndDeveloper.Shared.Helpers;

namespace TestWebBackEndDeveloper.Shared.Validator
{
    public class PurchaseRequestValidator : AbstractValidator<Purchase>
    {
        public PurchaseRequestValidator() 
        {
            RuleFor(p => p.AmountInvested)
                .NotEmpty()
                    .WithMessage(PurchaseErrors.Purchase_Error_AmountInvestedCanNotBeNullOrEmpty.Description())
                .GreaterThan(0)
                    .WithMessage(PurchaseErrors.Purchase_Error_AmountInvestedMustBeGreaterThanZero.Description());

            RuleFor(p => p.QuantityBTC)
                .NotEmpty()
                    .WithMessage(PurchaseErrors.Purchase_Error_QuantityBTCCanNotBeNullOrEmpty.Description())
                .GreaterThan(0)
                    .WithMessage(PurchaseErrors.Purchase_Error_QuantityBTCMustBeGreaterThanZero.Description());

            RuleFor(p => p.BTCExchangeRate)
                .NotEmpty()
                    .WithMessage(PurchaseErrors.Purchase_Error_BTCExchangeRateCCanNotBeNullOrEmpty.Description())
                .GreaterThan(0)
                    .WithMessage(PurchaseErrors.Purchase_Error_BTCExchangeRateBeGreaterThanZero.Description());
        }
    }
}