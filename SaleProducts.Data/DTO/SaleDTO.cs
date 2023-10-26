using Newtonsoft.Json;
using SaleProducts.Data.Models;

namespace SaleProducts.Data.DTO
{
    public class SaleDTO
    {
        [JsonProperty(PropertyName = "venta")]
        public Sale Sale { get; set; }

        [JsonProperty(PropertyName = "productos")]
        public List<Product> products { get; set; }

        [JsonProperty(PropertyName = "total")]
        public decimal Total { get; set; }
    }
}
