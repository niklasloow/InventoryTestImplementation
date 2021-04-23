using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class ContainArticleDto
    {
        public string ArtId { get; set; }

        [JsonPropertyName("amount_of")]
        public int AmountOf { get; set; }
    }

    public class ProductDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contain_articles")]
        public List<ContainArticleDto> ContainArticles { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
    public class ProductListDto
    {
        [JsonPropertyName("products")]
        public List<ProductDto> Products { get; set; }
    }


}
