using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum DepositErrors
    {
        [Description("'Value' can not be null or empty!")]
        Deposit_Error_ValueCanNotBeNullOrEmpty,

        [Description("'Value' must be greater than zero!")]
        Deposit_Error_ValueMustBeGreaterThanZero
    }
}