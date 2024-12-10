using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Tests.DomainTests.Entity
{
    public class PurchaseTests
    {
        [Fact]
        public void Constructor_ShouldInitializePurchaseDate()
        {
            var purchase = new Purchase();

            Assert.NotNull(purchase);
            Assert.True(purchase.PurchaseDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var accountUser = new AccountUser { Name = "John Doe" };
            var purchase = new Purchase
            {
                AccountId = 1,
                AmountInvested = 1000.00m,
                QuantityBTC = 0.05m,
                BTCExchangeRate = 20000.00m,
                PurchaseDate = new DateTime(2024, 1, 1),
                AccountUser = accountUser
            };

            Assert.Equal(1, purchase.AccountId);
            Assert.Equal(1000.00m, purchase.AmountInvested);
            Assert.Equal(0.05m, purchase.QuantityBTC);
            Assert.Equal(20000.00m, purchase.BTCExchangeRate);
            Assert.Equal(new DateTime(2024, 1, 1), purchase.PurchaseDate);
            Assert.NotNull(purchase.AccountUser);
            Assert.Equal("John Doe", purchase.AccountUser.Name);
        }

        [Fact]
        public void Properties_ShouldAllowNullAccountUser()
        {
            var purchase = new Purchase
            {
                AccountUser = null
            };

            Assert.Null(purchase.AccountUser);
        }
    }
}