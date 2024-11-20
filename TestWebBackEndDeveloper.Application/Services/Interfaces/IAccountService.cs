using System.Security.Principal;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> AddAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int accountId);
        Task<List<Account>> GetAllAccountsAsync();
    }
}