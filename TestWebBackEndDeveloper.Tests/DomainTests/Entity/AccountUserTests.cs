using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Tests.DomainTests.Entity
{
    public class AccountUserTests
    {
        [Fact]
        public void Constructor_ShouldInheritBaseEntity()
        {
            var accountUser = new AccountUser();

            Assert.NotNull(accountUser);
            Assert.True(accountUser.CreateDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var balance = new Balance { AccountId = 1, Value = 500.00m };
            var deposits = new List<Deposit>
            {
                new Deposit { AccountId = 1, Value = 100.00m },
                new Deposit { AccountId = 1, Value = 50.00m }
            };
            var purchases = new List<Purchase>
            {
                new Purchase
                {
                    AccountId = 1,
                    AmountInvested = 1000.00m,
                    QuantityBTC = 0.05m,
                    BTCExchangeRate = 20000.00m,
                    PurchaseDate = new System.DateTime(2024, 1, 1)
                }
            };

            var accountUser = new AccountUser
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "securepassword",
                Balance = balance,
                Deposits = deposits,
                Purchases = purchases
            };

            Assert.Equal("John Doe", accountUser.Name);
            Assert.Equal("johndoe@example.com", accountUser.Email);
            Assert.Equal("securepassword", accountUser.Password);
            Assert.NotNull(accountUser.Balance);
            Assert.Equal(500.00m, accountUser.Balance.Value);
            Assert.NotNull(accountUser.Deposits);
            Assert.Equal(2, accountUser.Deposits.Count);
            Assert.NotNull(accountUser.Purchases);
            Assert.Single(accountUser.Purchases);
            Assert.Equal(1000.00m, accountUser.Purchases.First().AmountInvested);
        }

        [Fact]
        public void Properties_ShouldAllowNullValues()
        {
            var accountUser = new AccountUser
            {
                Name = null,
                Email = null,
                Password = null,
                Balance = null,
                Deposits = null,
                Purchases = null
            };

            Assert.Null(accountUser.Name);
            Assert.Null(accountUser.Email);
            Assert.Null(accountUser.Password);
            Assert.Null(accountUser.Balance);
            Assert.Null(accountUser.Deposits);
            Assert.Null(accountUser.Purchases);
        }
    }
}