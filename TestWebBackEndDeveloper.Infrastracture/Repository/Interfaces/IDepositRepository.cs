using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IDepositRepository
    {
        Task<Deposit> AddDepositAsync(Deposit deposit);
        Deposit UpdateDepositAsync(Deposit deposit);
        Deposit DeleteDepositAsync(Deposit deposit);
        Task<List<Deposit>> GetAllDepositAsync();
    }
}