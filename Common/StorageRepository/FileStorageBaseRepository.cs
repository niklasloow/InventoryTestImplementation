using System;
using System.IO;
using System.Text.Json;

namespace Common.StorageRepository
{
    public class FileStorageBaseRepository<T> : IBaseStorageRepository<T>
    {
        private readonly string _path;

        public FileStorageBaseRepository(string fileName)
        {
            var filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException();

            _path = Path.Combine(filePath, $@"Data\{fileName}.json");
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
