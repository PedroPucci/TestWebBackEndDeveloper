using System.Text.Json.Serialization;

namespace TestWebBackEndDeveloper.Domain.General
{
    public abstract class BaseEntity
    {
        //[JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime? CreateDate { get; set; }

        [JsonIgnore]
        public DateTime? ModificationDate { get; set; }

        protected BaseEntity()
        {
            CreateDate = DateTime.UtcNow;
        }
    }
}