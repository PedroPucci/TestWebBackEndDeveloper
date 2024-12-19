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
        private PurchaseService purchaseService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW)
        {
            _repositoryUoW = repositoryUoW;
        }

        public AccountUserService AccountService
        {
            get
            {
                if (accountService is null)
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
                if (depositService is null)
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
                if (balanceService is null)
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
                if (quotationService is null)
                {
                    quotationService = new QuotationService(_repositoryUoW);
                }
                return quotationService;
            }
        }

        public PurchaseService PurchaseService
        {
            get
            {
                if (purchaseService is null)
                {
                    purchaseService = new PurchaseService(_repositoryUoW);
                }
                return purchaseService;
            }
        }
    }
}