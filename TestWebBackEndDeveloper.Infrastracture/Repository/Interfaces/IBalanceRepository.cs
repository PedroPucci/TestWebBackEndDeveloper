using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IBalanceRepository
    {
        Task<Balance> AddBalanceAsync(Balance balance);
    }
}