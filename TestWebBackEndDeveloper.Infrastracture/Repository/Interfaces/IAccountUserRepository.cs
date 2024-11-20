using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IAccountUserRepository
    {
        Task<AccountUser> AddAccountUserAsync(AccountUser accountUser);
        AccountUser UpdateAccountUserAsync(AccountUser accountUser);
        AccountUser DeleteAccountUserAsync(AccountUser accountUser);
        Task<List<AccountUser>> GetAllAccountUsersAsync();
        Task<AccountUser> GetAccountUserByIdAsync(int? id);
    }
}