using TestWebBackEndDeveloper.Application.Services;

namespace TestWebBackEndDeveloper.Application.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        AccountUserService AccountService { get; }
        DepositService DepositService { get; }
        BalanceService BalanceService { get; }
    }
}