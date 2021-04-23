using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.Models;

namespace Common.StorageRepository
{
    public class ProductRepository : IStorageRepository<Product>
    {
        private readonly IBaseStorageRepository<ProductListDto> _repository;
        private readonly IMapper _mapper;

        public ProductRepository(IBaseStorageRepository<ProductListDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Product GetById(string id)
        {
            var products = _repository.Read();
            var product = products.Products.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<Product>(product);
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _repository.Read();
            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}
