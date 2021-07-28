using Data.MongoDb.Abstruct;
using Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Concreate
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public async Task<IList<Order>> GetByCategoryId(string categoryId)
        {
            return await _collection.Find(x=> x.CategoryId == categoryId).ToListAsync();
        }
    }
}
