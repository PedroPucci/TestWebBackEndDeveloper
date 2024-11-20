using TestWebBackEndDeveloper.Application.Services.Interfaces;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class DepositService : IDepositService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public DepositService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public Task<Deposit> AddDepositAsync(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDepositAsync(int depositId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Deposit>> GetAllDepositsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Deposit> UpdateDepositAsync(Deposit deposit)
        {
            throw new NotImplementedException();
        }
    }
}