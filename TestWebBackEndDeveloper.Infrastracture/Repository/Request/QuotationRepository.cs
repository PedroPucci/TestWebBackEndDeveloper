using Microsoft.EntityFrameworkCore;
using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Infrastracture.Connection;
using TestWebBackEndDeveloper.Infrastracture.Repository.Interfaces;

namespace TestWebBackEndDeveloper.Infrastracture.Repository.Request
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly DataContext _context;

        public QuotationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Quotation> AddQuotationAsync(Quotation quotation)
        {
            var result = await _context.Quotation.AddAsync(quotation);
            return result.Entity;
        }

        public async Task<List<Quotation>> GetQuotationsAsync()
        {
            return await _context.Quotation
                .OrderBy(quotation => quotation.DateHourQuotation)
                .Select(quotation => new Quotation
                {
                   DateHourQuotation = quotation.DateHourQuotation,
                   SellPrice = quotation.SellPrice,
                   BuyPrice = quotation.BuyPrice,
                   Status = quotation.Status,
                   CreateDate = quotation.CreateDate
                }).ToListAsync();
        }
    }
}