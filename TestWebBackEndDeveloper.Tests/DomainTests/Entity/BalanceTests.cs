using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Tests.DomainTests.Entity
{
    public class BalanceTests
    {
        [Fact]
        public void Constructor_ShouldInheritBaseEntity()
        {
            var balance = new Balance();

            Assert.NotNull(balance);
            Assert.True(balance.CreateDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var accountUser = new AccountUser { Name = "John Doe" };
            var balance = new Balance
            {
                AccountId = 1,
                Value = 100.50m,
                AccountUsers = accountUser
            };

            Assert.Equal(1, balance.AccountId);
            Assert.Equal(100.50m, balance.Value);
            Assert.NotNull(balance.AccountUsers);
            Assert.Equal("John Doe", balance.AccountUsers.Name);
        }

        [Fact]
        public void Properties_ShouldAllowNullValues()
        {
            var balance = new Balance
            {
                AccountUsers = null,
                Value = 0m
            };

            Assert.Null(balance.AccountUsers);
            Assert.Equal(0m, balance.Value);
        }
    }
}