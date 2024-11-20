using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IAccountUserService
    {
        Task<Result<AccountUser>> AddAccountUserAsync(AccountUser accountUser);
        Task<Result<AccountUser>> UpdateAccountUserAsync(AccountUser accountUser);
        Task DeleteAccountUserAsync(int accountUserId);
        Task<List<AccountUser>> GetAllAccountUsersAsync();
    }
}