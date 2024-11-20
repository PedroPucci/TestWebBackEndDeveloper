using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class Balance : BaseEntity
    {
        public AccountUser? AccountUsers { get; set; }
        public double Value { get; set; }
    }
}