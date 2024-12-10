using System.Text.Json.Serialization;
using TestWebBackEndDeveloper.Domain.General;

namespace TestWebBackEndDeveloper.Domain.Entity
{
    public class Purchase : BaseEntity
    {
        public int AccountId { get; set; }
        public decimal AmountInvested { get; set; }
        public decimal QuantityBTC { get; set; } 
        public decimal BTCExchangeRate { get; set; } 
        public DateTime PurchaseDate { get; set; }

        [JsonIgnore]
        public AccountUser? AccountUser { get; set; }

        public Purchase()
        {
            PurchaseDate = DateTime.UtcNow;
        }
    }
}