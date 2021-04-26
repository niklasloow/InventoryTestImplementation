using System;
using Better.RandomDataGenerator;
using Common.Models;
using Common.SellingService;
using Common.StorageRepository.Interfaces;
using Common.Tests.Builders;
using FakeItEasy;
using Xunit;

namespace Common.Tests.SellingService
{
    public class StockServiceShould
    {
        private readonly IStorageRepository<Article> _articleRepository;
        private readonly IStorageRepository<Product> _productRepository;
        private readonly StockService _sut;
        public StockServiceShould()
        {
            _articleRepository = A.Fake<IStorageRepository<Article>>();
            _productRepository = A.Fake<IStorageRepository<Product>>();
            _sut = new StockService(_articleRepository, _productRepository);
        }

        [Fact]
        public void CallUpdateArticleRepository()
        {
            //Arrange
            var articleId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            var amountOf = RandomDataGenerator.IntGenerator.GetRandomNumberInRange(1, 50);
            var product = new ProductBuilder()
                .Default()
                .WithContainingArticle(articleId, amountOf)
                .Build();

            var article = new ArticleBuilder()
                .Default()
                .TypicalArticle()
                .Build();

            var productId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            A.CallTo(() => _productRepository.GetById(A<string>.Ignored)).Returns(product); 
            A.CallTo(() => _articleRepository.GetById(A<string>.Ignored)).Returns(article); 
            
            //Act
            _sut.DecreaseArticleStockForProduct(productId);
            
            //Assert
            A.CallTo(() => _articleRepository.Update(article)).MustHaveHappened();
        }

        [Fact]
        public void LowerStockAmount()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void WorkWithFaultyData()
        {
            var productId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            A.CallTo(() => _productRepository.GetById(A<string>.Ignored)).Returns(null);
            A.CallTo(() => _articleRepository.GetById(A<string>.Ignored)).Returns(null);

            _sut.DecreaseArticleStockForProduct(productId);

            A.CallTo(() => _articleRepository.Update(A<Article>.Ignored)).MustHaveHappened();
        }
    }
}
