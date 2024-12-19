namespace TestWebBackEndDeveloper.Shared.Logging
{
    public static class LogMessages
    {
        //AccountUser
        public static string InvalidAccountUserInputs() => "Message: Invalid inputs to AccountUser.";
        public static string NullOrEmptyAccountUserName() => "Message: The Name field is null, empty, or whitespace.";
        public static string UpdatingErrorAccountUser(Exception ex) => $"Message: Error updating AccountUser: {ex.Message}";
        public static string UpdatingSuccessAccountUser() => "Message: Successfully updated AccountUser.";
        public static string AccountUserNotFound(string action) => $"Message: AccountUser not found for {action} action.";
        public static string AddingAccountUserError(Exception ex) => $"Message: Error adding a new AccountUser: {ex.Message}";
        public static string AddingAccountUserSuccess() => "Message: Successfully added a new AccountUser.";
        public static string DeleteAccountUserError(Exception ex) => $"Message: Error to delete a AccountUser: {ex.Message}";
        public static string DeleteAccountUserSuccess() => "Message: Delete with success AccountUser.";
        public static string GetAllAccountUserError(Exception ex) => $"Message: Error to loading the list AccountUser: {ex.Message}";
        public static string GetAllAccountUserSuccess() => "Message: GetAll with success AccountUser.";
    }
}