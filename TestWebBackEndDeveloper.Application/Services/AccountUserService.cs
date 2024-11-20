using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class AccountUserService : IAccountUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public AccountUserService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Result<AccountUser>> AddAccountUserAsync(AccountUser accountUser)
        {
            throw new NotImplementedException();
        }

        public Task<Result<AccountUser>> UpdateAccountUserAsync(AccountUser accountUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountUserAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountUser>> GetAllAccountUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}