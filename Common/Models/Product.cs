using System.Collections.Generic;
using System.Linq;
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
        public decimal Price { get; set; }

        [JsonPropertyName("stock")]
        public decimal Stock => this.CalculateStock();
    }

    public static class ProductHelper
    {
        public static int CalculateStock(this Product product)
        {
            //TODO need to fetch article, and cant be a static helper then
            var article = new Article
            {
                ArtId = "",
                Stock = 20,
                Name = ""
            };
            var values = product.ContainArticles.Select(
                containArticle => article.Stock / containArticle.AmountOf).ToList();

            return values.OrderBy(p => p).First();
        }
    }

}
