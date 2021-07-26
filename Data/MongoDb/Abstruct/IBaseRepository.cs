using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Abstruct
{
    public interface IBaseRepository<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<bool> AddAsync(T value);
        Task<bool> UpdateAsync(T value);
        Task<bool> DeleteAsync(T value);
    }
}
