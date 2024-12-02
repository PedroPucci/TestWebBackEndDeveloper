using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> AddBitcoinAsync(Purchase purchase);
    }
}