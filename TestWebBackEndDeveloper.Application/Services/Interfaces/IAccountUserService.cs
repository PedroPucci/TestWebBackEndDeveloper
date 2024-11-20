using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IAccountUserService
    {
        Task<AccountUser> AddAccountUserAsync(AccountUser accountUser);
        Task<AccountUser> UpdateAccountUserAsync(AccountUser accountUser);
        Task DeleteAccountUserAsync(int accountUserId);
        Task<List<AccountUser>> GetAllAccountUsersAsync();
    }
}