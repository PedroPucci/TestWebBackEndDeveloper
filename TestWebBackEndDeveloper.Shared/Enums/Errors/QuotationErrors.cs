using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum QuotationErrors
    {
        [Description("'BuyPrice' can not be null or empty!")]
        Quotation_Error_BuyPriceCanNotBeNullOrEmpty,

        [Description("'SellPrice' can not be null or empty!")]
        Quotation_Error_SellPriceCanNotBeNullOrEmpty
    }
}