using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum AcountUserErrors
    {
        [Description("'Name' can not be null or empty!")]
        AccountUser_Error_NameCanNotBeNullOrEmpty,

        [Description("'Name' can not be less 4 letters!")]
        AccountUser_Error_NameLenghtLessFour,

        [Description("'Email' can not be null or empty!")]
        AccountUser_Error_EmailCanNotBeNullOrEmpty,

        [Description("'Email' invalid format!")]
        AccountUser_Error_InvalidEmailFormat,

        [Description("'Email' can not be less 4 letters!")]
        AccountUser_Error_EmailLenghtLessFour,

        [Description("'Password' must have at least 4 letters and 2 numbers!")]
        AccountUser_Error_PasswordInvalid,

        [Description("'Password' can not be null or empty!")]
        AccountUser_Error_PasswordCanNotBeNullOrEmpty,

        [Description("'Password' can not be less 4 letters!")]
        AccountUser_Error_PasswordLenghtLessFour
    }
}