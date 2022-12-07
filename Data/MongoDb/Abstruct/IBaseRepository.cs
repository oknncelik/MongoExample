using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Abstruct
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T value);
        Task<T> UpdateAsync(T value);
        Task<bool> DeleteAsync(T value);
        IMongoCollection<T> GetCollection<T>();
    }
}
