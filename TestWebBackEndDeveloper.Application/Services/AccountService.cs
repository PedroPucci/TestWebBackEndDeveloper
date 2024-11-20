using TestWebBackEndDeveloper.Application.Services.Interfaces;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class AccountService : IBalanceService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public AccountService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Balance> AddBalanceAsync(Balance balance)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBalanceAsync(int balanceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Balance>> GetAllBalancesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Balance> UpdateBalanceAsync(Balance balance)
        {
            throw new NotImplementedException();
        }
    }
}