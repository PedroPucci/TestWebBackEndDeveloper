using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _context;

        public BalanceRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Balance> AddBalanceAsync(Balance balance)
        {
            throw new NotImplementedException();
        }

        public Balance DeleteBalanceAsync(Balance balance)
        {
            throw new NotImplementedException();
        }

        public Task<List<Balance>> GetAllBalanceAsync()
        {
            throw new NotImplementedException();
        }

        public Balance UpdateBalanceAsync(Balance balance)
        {
            throw new NotImplementedException();
        }
    }
}