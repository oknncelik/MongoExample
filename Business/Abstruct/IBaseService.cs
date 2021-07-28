using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstruct
{
    public interface IBaseService<T,CT, UT>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(CT value);
        Task<T> UpdateAsync(UT value);
        Task<bool> DeleteAsync(T value);
    }
}
