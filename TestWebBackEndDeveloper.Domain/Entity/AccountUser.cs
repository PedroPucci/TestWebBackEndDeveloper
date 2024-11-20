using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class AccountUser : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Deposit> Deposits { get; set; }
        public Balance Balance { get; set; }
    }
}