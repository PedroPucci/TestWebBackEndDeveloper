namespace TestWebBackEndDeveloper.Application.UnitOfWork
{
    public interface IUnitOfWorkService
    {
        AccountService AccountService { get; }
        DepositService DepositService { get; }
        BalanceService BalanceService { get; }
    }
}