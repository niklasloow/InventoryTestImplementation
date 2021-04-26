using Better.RandomDataGenerator;
using Common.Models;

namespace Common.Tests.Builders
{
    public class ArticleBuilder
    {
        private string _name;
        private int _stock;
        private string _artId;

        public ArticleBuilder Default()
        {
            return this;
        }

        public ArticleBuilder TypicalArticle()
        {
            _artId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            _name = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            _stock = RandomDataGenerator.IntGenerator.GetRandomNumberInRange(1, 50);
            return this;
        }

        public Article Build()
        {
            return new Article
            {
                ArtId = _artId,
                Stock = _stock,
                Name = _name
            };
        }
    }
}