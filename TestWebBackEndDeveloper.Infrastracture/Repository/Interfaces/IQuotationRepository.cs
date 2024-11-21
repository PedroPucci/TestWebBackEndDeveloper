using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces
{
    public interface IQuotationRepository
    {
        Task<Quotation> AddQuotationAsync(Quotation quotation);
        Task<List<Quotation>> GetQuotationsAsync();
    }
}