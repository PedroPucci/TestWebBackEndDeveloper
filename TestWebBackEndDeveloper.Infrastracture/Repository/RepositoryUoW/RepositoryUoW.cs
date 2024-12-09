using Microsoft.EntityFrameworkCore.Storage;
using Serilog;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;
using TestWebBackEndDeveloper.Infrastracture.Repository.Request;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.RepositoryUoW
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataContext _context;
        private bool _disposed = false;
        private IAccountUserRepository? _accountUserRepository = null;
        private IDepositRepository? _depositRepository = null;
        private IBalanceRepository? _balanceRepository = null;
        private IQuotationRepository? _quotationRepository = null;
        private IPurchaseRepository? _purchaseRepository = null;

        public RepositoryUoW(DataContext context)
        {
            _context = context;
        }

        public IAccountUserRepository AccountUserRepository
        {
            get
            {
                if (_accountUserRepository == null)
                {
                    _accountUserRepository = new AccountUserRepository(_context);
                }
                return _accountUserRepository;
            }
        }

        public IDepositRepository DepositRepository
        {
            get
            {
                if (_depositRepository == null)
                {
                    _depositRepository = new DepositRepository(_context);
                }
                return _depositRepository;
            }
        }

        public IBalanceRepository BalanceRepository
        {
            get
            {
                if (_balanceRepository == null)
                {
                    _balanceRepository = new BalanceRepository(_context);
                }
                return _balanceRepository;
            }
        }

        public IQuotationRepository QuotationRepository
        {
            get
            {
                if (_quotationRepository == null)
                {
                    _quotationRepository = new QuotationRepository(_context);
                }
                return _quotationRepository;
            }
        }

        public IPurchaseRepository PurchaseRepository
        {
            get
            {
                if (_purchaseRepository == null)
                {
                    _purchaseRepository = new PurchaseRepository(_context);
                }
                return _purchaseRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error($"Database connection failed: {ex.Message}");
                throw new ApplicationException("Database is not available. Please check the connection.");
            }
        }        

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}