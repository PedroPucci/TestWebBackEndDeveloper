using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum QuotationErrors
    {
        [Description("'BuyPrice' can not be null or empty!")]
        Quotation_Error_BuyPriceCanNotBeNullOrEmpty,

        [Description("'BuyPrice' buy price must be greater than zero!")]
        Quotation_Error_BuyPriceMustBeGreaterThanZero,

        [Description("'SellPrice' can not be null or empty!")]
        Quotation_Error_SellPriceCanNotBeNullOrEmpty,

        [Description("'SellPrice' sell price must be greater than zero!")]
        Quotation_Error_SellPriceMustBeGreaterThanZero
    }
}