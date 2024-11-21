using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IBalanceService
    {
        Task<Balance> GetBalanceByIdAccount(int id);
    }
}