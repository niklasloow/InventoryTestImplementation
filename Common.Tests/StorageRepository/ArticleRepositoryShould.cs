using AutoMapper;
using Better.RandomDataGenerator;
using Common.Models;
using Common.Models.Dto;
using Common.StorageRepository;
using Common.StorageRepository.Interfaces;
using Common.Tests.Builders;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Common.Tests.StorageRepository
{
    public class ArticleRepositoryShould
    {
        private readonly Common.StorageRepository.ArticleRepository _sut;
        private readonly IBaseStorageRepository<InventoryListDto> _baseStorageRepository;

        public ArticleRepositoryShould()
        {
            _baseStorageRepository = A.Fake<IBaseStorageRepository<InventoryListDto>>();
            _sut = new Common.StorageRepository.ArticleRepository(_baseStorageRepository, A.Fake<IMapper>());
        }

        [Fact]
        public void ReturnCorrectArticle()
        {
            //Arrange 
            var artId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            var inventoryResponse = new InventoryDtoBuilder()
                .Default()
                .WithArticle(artId, 
                    RandomDataGenerator.StringGenerator.GetRandomTinyString(), 
                    RandomDataGenerator.StringGenerator.GetRandomTinyString())
                .Build();
            A.CallTo(() => _baseStorageRepository.Read()).Returns(inventoryResponse);
            
            //Act
            var article = _sut.GetById(artId);

            //Assert
            A.CallTo(() => _baseStorageRepository.Read()).MustHaveHappenedOnceExactly();
            article.ArtId.Should().Be(artId);
        }

        [Fact]
        public void CallMapper()
        {
            var artId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            var inventoryResponse = new InventoryDtoBuilder()
                .Default()
                .WithArticle(artId,
                    RandomDataGenerator.StringGenerator.GetRandomTinyString(),
                    RandomDataGenerator.StringGenerator.GetRandomTinyString())
                .Build();
            A.CallTo(() => _baseStorageRepository.Read()).Returns(inventoryResponse);

            //Act
            var article = _sut.GetById(artId);

            //Assert
            A.CallTo(() => _baseStorageRepository.Read()).MustHaveHappenedOnceExactly();
            article.ArtId.Should().Be(artId);
        }
        
        [Fact]
        public void NotThrowExWithFaultyData()
        {
            //Arrange 
            var artId = RandomDataGenerator.StringGenerator.GetRandomTinyString();
            A.CallTo(() => _baseStorageRepository.Read()).Returns(null);

            //Act
            _ = _sut.GetById(artId);

            //Assert
            A.CallTo(() => _baseStorageRepository.Read()).MustHaveHappenedOnceExactly();
        }
    }
}
