using Serilog;
using System.Xml.Linq;
using TestWebBackEndDeveloper.Application.Services.Interfaces;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;

namespace TestWebBackEndDeveloper.Application.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IRepositoryUoW _repositoryUoW;

        public BalanceService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public async Task<Balance> GetBalanceByIdAccount(int id)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                if (id <= 0)
                {
                    Log.Error("Id can not be empty or null!");
                    throw new InvalidOperationException("Id can not be empty or null!");
                }
                
                double value = await _repositoryUoW.DepositRepository.GetTotalDepositsByAccountIdAsync(id);

                if (value == 0)
                {
                    Log.Error("Message: Error to load the Balance");
                    throw new InvalidOperationException("Balance not found!");
                }

                Balance balance = new Balance
                {
                    Value = (decimal)value,
                    AccountId = id,
                    CreateDate = DateTime.UtcNow
                };

                _repositoryUoW.Commit();
                return balance;
            }
            catch (Exception ex)
            {
                Log.Error("Message: Error to loading the list Balance " + ex + "");
                transaction.Rollback();
                throw new InvalidOperationException("An error occurred");
            }
            finally
            {
                Log.Error("Message: GetAllMovie with success Balance");
                transaction.Dispose();
            }
        }
    }
}