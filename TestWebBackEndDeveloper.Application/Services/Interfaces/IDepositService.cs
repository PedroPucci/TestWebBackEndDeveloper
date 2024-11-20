using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IDepositService
    {
        Task<Deposit> AddDepositAsync(Deposit deposit);
        Task<Deposit> UpdateDepositAsync(Deposit deposit);
        Task DeleteDepositAsync(int depositId);
        Task<List<Deposit>> GetAllDepositsAsync();
    }
}