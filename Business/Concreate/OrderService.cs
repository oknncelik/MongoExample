using AutoMapper;
using Business.Abstruct;
using Data.MongoDb.Abstruct;
using Entities;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class OrderService : IOrderService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(ICategoryRepository categoryRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderModel> AddAsync(OrderCreate value)
        {
            return _mapper.Map<OrderModel>(await _orderRepository.AddAsync(_mapper.Map<Order>(value)));
        }

        public async Task<bool> DeleteAsync(OrderModel value)
        {
            return await _orderRepository.DeleteAsync(_mapper.Map<Order>(value));
        }

        public async Task<IList<OrderModel>> GetAllAsync()
        {
            var result = await _orderRepository.GetAllAsync();
            foreach (var item in result)
                item.Category = await _categoryRepository.GetByIdAsync(item.CategoryId);
            return _mapper.Map<IList<OrderModel>>(result);
        }

        public async Task<IList<OrderModel>> GetBayCategoryId(string categoryId)
        {
            var result = await _orderRepository.GetByCategoryId(categoryId);
            foreach (var item in result)
                item.Category = await _categoryRepository.GetByIdAsync(item.CategoryId);
            return _mapper.Map<IList<OrderModel>>(result);
        }

        public async Task<OrderModel> GetByIdAsync(string id)
        {
            var result = await _orderRepository.GetByIdAsync(id);
            result.Category = await _categoryRepository.GetByIdAsync(result.CategoryId);
            return _mapper.Map<OrderModel>(result);
        }

        public async Task<OrderModel> UpdateAsync(OrderUpdate value)
        {
            return _mapper.Map<OrderModel>(await _orderRepository.UpdateAsync(_mapper.Map<Order>(value)));
        }
    }
}
