using System.Collections.Generic;
using Common.Models;

namespace Common.SellingService
{
    public class ProductBuilder
    {
        private List<ContainArticle> _containingArticles;

        public ProductBuilder Default()
        {
            _containingArticles = new List<ContainArticle>();
            return this;
        }

        public ProductBuilder WithContainingArticle(string artId, int amountOf)
        {
            _containingArticles.Add(new ContainArticle
            {
                ArtId = artId,
                AmountOf = amountOf
            });
            return this;
        }

        public Product Build()
        {
            return new Product
            {
                ContainArticles = _containingArticles
            };
        }
    }
}