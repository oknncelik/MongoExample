using Business.Abstruct;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(CategoryUpdate category)
        {
            return Ok(await _categoryService.UpdateAsync(category));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryCreate categoryCreate)
        {
            return Ok(await _categoryService.AddAsync(categoryCreate));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(CategoryModel category)
        {
            return Ok(await _categoryService.DeleteAsync(category));
        }
    }
}
