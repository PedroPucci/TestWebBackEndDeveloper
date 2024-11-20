using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IDepositService
    {
        Task<Result<Deposit>> AddDepositAsync(Deposit deposit);
    }
}