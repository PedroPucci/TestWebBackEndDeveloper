using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum AcountUserErrors
    {
        [Description("'Name' can not be null or empty!")]
        AccountUser_Error_NameCanNotBeNullOrEmpty,

        [Description("'Email' can not be less 10 letters!")]
        AccountUser_Error_EmailCanNotBeNullOrEmpty,

        [Description("'Name' must be provided and cannot contain only whitespace!")]
        AccountUser_Error_NameCanNotContainOnlyWhitespace,

        [Description("'Password' must have at least 4 letters and 2 numbers!")]
        AccountUser_Error_PasswordInvalid
    }
}