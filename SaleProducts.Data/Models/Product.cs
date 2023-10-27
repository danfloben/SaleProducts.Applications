using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SaleProducts.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "codigo")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "precio_unitario")]
        public decimal UnitPrice { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "subtotal")]
        public decimal Subtotal { get; set; }

        public Sale? Sale { get; set; }
    }
}
