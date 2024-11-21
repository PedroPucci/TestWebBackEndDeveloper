using TestWebBackEndDeveloper.Application.ExtensionError;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Application.Services.Interfaces
{
    public interface IQuotationService
    {
        Task<Result<Quotation>> AddQuotationAsync(Quotation quotation);
        Task<List<Quotation>> GetAllQuotationsAsync();
        Task<List<Quotation>> GetAllQuotationsBuyAsync();
        Task<List<Quotation>> GetAllQuotationsSellAsync();
    }
}