using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DataContext _context;

        public PurchaseRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Purchase> AddBitcoinAsync(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}