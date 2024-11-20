using System.ComponentModel;

namespace TestWebBackEndDeveloper.Shared.Enums.Errors
{
    public enum AcountUserErrors
    {
        [Description("'Name' can not be null or empty!")]
        AccountUser_Error_NameCanNotBeNullOrEmpty,

        [Description("'Email' can not be less 10 letters!")]
        AccountUser_Error_EmailCanNotBeNullOrEmpty
    }
}