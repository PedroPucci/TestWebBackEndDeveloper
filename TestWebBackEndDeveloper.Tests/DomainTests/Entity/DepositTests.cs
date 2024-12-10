using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Tests.DomainTests.Entity
{
    public class DepositTests
    {
        [Fact]
        public void Constructor_ShouldInheritBaseEntity()
        {
            var deposit = new Deposit();

            Assert.NotNull(deposit);
            Assert.True(deposit.CreateDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var accountUser = new AccountUser { Name = "John Doe" };
            var deposit = new Deposit
            {
                AccountId = 1,
                Value = 200.50m,
                AccountUsers = accountUser
            };

            Assert.Equal(1, deposit.AccountId);
            Assert.Equal(200.50m, deposit.Value);
            Assert.NotNull(deposit.AccountUsers);
            Assert.Equal("John Doe", deposit.AccountUsers.Name);
        }

        [Fact]
        public void Properties_ShouldAllowNullValues()
        {
            var deposit = new Deposit
            {
                AccountUsers = null,
                Value = 0m
            };

            Assert.Null(deposit.AccountUsers);
            Assert.Equal(0m, deposit.Value);
        }
    }
}