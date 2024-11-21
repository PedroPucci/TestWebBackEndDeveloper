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
                .GreaterThan(0)
                .WithMessage(QuotationErrors.Quotation_Error_BuyPriceCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.SellPrice)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(QuotationErrors.Quotation_Error_SellPriceCanNotBeNullOrEmpty.Description());
        }
    }
}