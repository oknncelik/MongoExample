using Business.Abstruct;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _orderService.GetByIdAsync(id));
        }

        [HttpGet("getbycategoryid")]
        public async Task<IActionResult> GetByCategoryId(string categoryId)
        {
            return Ok(await _orderService.GetBayCategoryId(categoryId));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(OrderUpdate order)
        {
            return Ok(await _orderService.UpdateAsync(order));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OrderCreate order)
        {
            return Ok(await _orderService.AddAsync(order));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(OrderModel order)
        {
            return Ok(await _orderService.DeleteAsync(order));
        }
    }
}
