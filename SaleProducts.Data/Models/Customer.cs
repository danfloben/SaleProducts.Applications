using Newtonsoft.Json;

namespace SaleProducts.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "direccion")]
        public string? Address { get; set; }

        [JsonProperty(PropertyName = "telefono")]
        public string? Phone { get; set; }
    }
}
