namespace Common.StorageRepository.Interfaces
{
    public interface IBaseStorageRepository<T>
    {
        void Create(T model);
        //TODO - Maybe
        T Read();
        void Update(T model);
        void Delete(string id);
    }
}
