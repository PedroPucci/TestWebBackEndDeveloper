using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum PurchaseErrors
    {
        [Description("'AmountInvested' Amount invested must be greater than zero!")]
        Purchase_Error_AmountInvestedMustBeGreaterThanZero,

        [Description("'AmountInvested' Amount invested can not be null or empty!")]
        Purchase_Error_AmountInvestedCanNotBeNullOrEmpty,

        [Description("'QuantityBTC' Quantity BTC must be greater than zero!")]
        Purchase_Error_QuantityBTCMustBeGreaterThanZero,

        [Description("'QuantityBTC' Quantity BTC can not be null or empty!")]
        Purchase_Error_QuantityBTCCanNotBeNullOrEmpty,

        [Description("'BTCExchangeRate' ExchangeRate BTC must be greater than zero!")]
        Purchase_Error_BTCExchangeRateBeGreaterThanZero,

        [Description("'BTCExchangeRate' ExchangeRate BTC can not be null or empty!")]
        Purchase_Error_BTCExchangeRateCCanNotBeNullOrEmpty
    }
}