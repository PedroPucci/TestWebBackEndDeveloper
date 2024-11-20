using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class DepositRepository : IDepositRepository
    {
        private readonly DataContext _context;

        public DepositRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Deposit> AddDepositAsync(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public Deposit DeleteDepositAsync(Deposit deposit)
        {
            throw new NotImplementedException();
        }

        public Task<List<Deposit>> GetAllDepositAsync()
        {
            throw new NotImplementedException();
        }

        public Deposit UpdateDepositAsync(Deposit deposit)
        {
            throw new NotImplementedException();
        }
    }
}