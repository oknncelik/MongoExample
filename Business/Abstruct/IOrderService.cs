using Entities.Dtos;

namespace Business.Abstruct
{
    public interface IOrderService : IBaseService<OrderModel, OrderCreate, OrderUpdate>
    {
    }
}
