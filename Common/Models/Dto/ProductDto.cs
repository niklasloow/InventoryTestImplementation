using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class ContainArticleDto
    {
        [JsonPropertyName("art_id")]
        public string ArtId { get; set; }

        [JsonPropertyName("amount_of")]
        public string AmountOf { get; set; }
    }

    public class ProductDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contain_articles")]
        public List<ContainArticleDto> ContainArticles { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("price")]
        public string Price { get; set; }
    }
    public class ProductListDto
    {
        [JsonPropertyName("products")]
        public List<ProductDto> Products { get; set; }
    }


}
