using Data.MongoDb.Abstruct;
using Entities;

namespace Data.MongoDb.Concreate
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
    }
}
