using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Tests.DomainTests.General
{
    public class BaseEntityTests
    {
        private class TestEntity : BaseEntity { }

        [Fact]
        public void Constructor_ShouldInitializeCreateDate()
        {
            var entity = new TestEntity();

            Assert.NotNull(entity.CreateDate);
            Assert.True(entity.CreateDate <= DateTime.UtcNow);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            var entity = new TestEntity();
            var testId = 123;
            var testCreateDate = new DateTime(2023, 01, 01);
            var testModificationDate = new DateTime(2024, 01, 01);

            entity.Id = testId;
            entity.CreateDate = testCreateDate;
            entity.ModificationDate = testModificationDate;

            Assert.Equal(testId, entity.Id);
            Assert.Equal(testCreateDate, entity.CreateDate);
            Assert.Equal(testModificationDate, entity.ModificationDate);
        }
    }
}