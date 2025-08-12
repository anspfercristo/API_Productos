using System.Text.Json.Serialization;

namespace Models
{
    public class Products
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("price")]
        public decimal? Price { get; set; }
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }
        [JsonPropertyName("rating")]
        public double? Rating { get; set; }
        [JsonPropertyName("specs")]
        public Dictionary<string, object>? Specs { get; set; }

    }
}
