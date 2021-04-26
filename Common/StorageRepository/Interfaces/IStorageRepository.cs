using System.Collections.Generic;

namespace Common.StorageRepository.Interfaces
{
    public interface IStorageRepository<TEntity>
    {
        TEntity GetById(string id);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}