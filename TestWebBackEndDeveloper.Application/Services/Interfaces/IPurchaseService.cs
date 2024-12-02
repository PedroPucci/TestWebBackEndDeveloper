using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<Result<Quotation>> AddBitcoinAsync(Purchase purchase);
    }
}