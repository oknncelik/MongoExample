using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstruct
{
    public interface IOrderService : IBaseService<OrderModel, OrderCreate, OrderUpdate>
    {
        Task<IList<OrderModel>> GetBayCategoryId(string categoryId);
    }
}
