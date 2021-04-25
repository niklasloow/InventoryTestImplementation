using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class ContainArticle
    {
        public string ArtId { get; set; }

        [JsonPropertyName("amount_of")]
        public int AmountOf { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contain_articles")]
        public List<ContainArticle> ContainArticles { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }
    }

}
