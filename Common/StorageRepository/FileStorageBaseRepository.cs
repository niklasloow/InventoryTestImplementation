using System;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Common.StorageRepository
{
    public class FileStorageBaseRepository<T> : IBaseStorageRepository<T>
    {
        private readonly string _path;

        public FileStorageBaseRepository(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException();
            _path = $@"C:\Repositories\Personal Projects\InventoryTestImplementation\Common\Data\{fileName}.json";
        }

        public void Create(T model)
        {
            throw new NotImplementedException();
        }

        public T Read()
        {
            var file = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<T>(file);
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
