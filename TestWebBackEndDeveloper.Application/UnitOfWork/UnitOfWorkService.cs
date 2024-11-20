using TestWebBackEndDeveloper.Application.Services;

namespace TestWebBackEndDeveloper.Application.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private AccountService accountService;
        private DepositService depositService;
        private BalanceService balanceService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public AccountService AccountService
        {
            get
            {
                if (accountService == null)
                {
                    accountService = new AccountService(_repositoryUoW);
                }
                return accountService;
            }
        }

        public DepositService DepositService
        {
            get
            {
                if (depositService == null)
                {
                    depositService = new DepositService(_repositoryUoW);
                }
                return depositService;
            }
        }

        public BalanceService BalanceService
        {
            get
            {
                if (balanceService == null)
                {
                    balanceService = new BalanceService(_repositoryUoW);
                }
                return balanceService;
            }
        }
    }
}