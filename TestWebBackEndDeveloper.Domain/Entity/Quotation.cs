using TestWebBackEndDeveloper.Domain.Enum;
using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class Quotation : BaseEntity
    {
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime DateHourQuotation { get; set; }
        public QuotationStatus Status { get; set; }
    }
}