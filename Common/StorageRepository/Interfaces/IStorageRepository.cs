using System.Collections.Generic;
using Common.Models;

namespace Common.StorageRepository
{
    public interface IStorageRepository<TEntity>
    {
        TEntity GetById(string id);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}