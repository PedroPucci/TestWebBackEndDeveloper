using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IBalanceService
    {
        Task<Balance> AddBalanceAsync(Balance balance);
        Task<Balance> UpdateBalanceAsync(Balance balance);
        Task DeleteBalanceAsync(int balanceId);
        Task<List<Balance>> GetAllBalancesAsync();
    }
}