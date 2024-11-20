using System.Text.Json.Serialization;
using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class Deposit : BaseEntity
    {
        public int AccountId { get; set; }

        [JsonIgnore]
        public AccountUser? AccountUsers { get; set; }

        public decimal Value { get; set; }
    }
}