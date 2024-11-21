using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IDepositRepository
    {
        Task<Deposit> AddDepositAsync(Deposit deposit);
        Task<double> GetTotalDepositsByAccountIdAsync(int accountUserId);
    }
}