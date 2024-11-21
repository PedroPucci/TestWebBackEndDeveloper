using TestWebBackEndDeveloper.Application.Services;
using TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW;

namespace TestWebBackEndDeveloper.Application.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private AccountUserService accountService;
        private DepositService depositService;
        private BalanceService balanceService;
        private QuotationService quotationService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public AccountUserService AccountService
        {
            get
            {
                if (accountService == null)
                {
                    accountService = new AccountUserService(_repositoryUoW);
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

        public QuotationService QuotationService
        {
            get
            {
                if (quotationService == null)
                {
                    quotationService = new QuotationService(_repositoryUoW);
                }
                return quotationService;
            }
        }
    }
}