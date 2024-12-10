using TestWebBackEndDeveloper.Domain.Entity;
using TestWebBackEndDeveloper.Domain.Enum;

namespace TestWebBackEndDeveloper.Tests.DomainTests.Entity
{
    public class QuotationTests
    {
        [Fact]
        public void Constructor_ShouldInheritBaseEntity()
        {
            var quotation = new Quotation();

            Assert.NotNull(quotation);
            Assert.True(quotation.CreateDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var quotation = new Quotation
            {
                BuyPrice = 25000.00m,
                SellPrice = 25500.00m,
                DateHourQuotation = new DateTime(2024, 1, 1, 12, 0, 0),
                Status = QuotationStatus.Buy,
            };

            Assert.Equal(25000.00m, quotation.BuyPrice);
            Assert.Equal(25500.00m, quotation.SellPrice);
            Assert.Equal(new DateTime(2024, 1, 1, 12, 0, 0), quotation.DateHourQuotation);
            Assert.Equal(QuotationStatus.Buy, quotation.Status);
        }
    }
}