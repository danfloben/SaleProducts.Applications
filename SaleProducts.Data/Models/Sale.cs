using Newtonsoft.Json;

namespace SaleProducts.Data.Models
{    public class Sale
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string? Number { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public Customer? Customer { get; set; }
    }
}
