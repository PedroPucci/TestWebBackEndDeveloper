using FluentValidation;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Shared.Enums.Errors;
using TestWebBackEndDeveloper.Shared.Helpers;

namespace TestWebBackEndDeveloper.Shared.Validator
{
    public class QuotationRequestValidator : AbstractValidator<Quotation>
    {
        public QuotationRequestValidator()
        {
            RuleFor(p => p.BuyPrice)
                .NotEmpty()
                    .WithMessage(QuotationErrors.Quotation_Error_BuyPriceCanNotBeNullOrEmpty.Description())
                .GreaterThan(0)
                    .WithMessage(QuotationErrors.Quotation_Error_BuyPriceMustBeGreaterThanZero.Description());

            RuleFor(p => p.SellPrice)
                .NotEmpty()
                    .WithMessage(QuotationErrors.Quotation_Error_SellPriceCanNotBeNullOrEmpty.Description())
                .GreaterThan(0)
                    .WithMessage(QuotationErrors.Quotation_Error_SellPriceMustBeGreaterThanZero.Description());
        }
    }
}