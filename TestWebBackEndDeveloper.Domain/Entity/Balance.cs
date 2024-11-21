using System.Text.Json.Serialization;
using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class Balance : BaseEntity
    {
        [JsonIgnore]
        public AccountUser? AccountUsers { get; set; }

        public int AccountId { get; set; }

        public decimal Value { get; set; }
    }
}