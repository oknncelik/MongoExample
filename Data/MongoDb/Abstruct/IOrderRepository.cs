using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Abstruct
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IList<Order>> GetByCategoryId(string categoryId);
    }
}
