using AutoMapper;
using Business.Abstruct;
using Data.MongoDb.Abstruct;
using Entities;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(CategoryCreate value)
        {
            return await _categoryRepository.AddAsync(_mapper.Map<Category>(value));
        }

        public async Task<bool> DeleteAsync(CategoryModel value)
        {
            return await _categoryRepository.DeleteAsync(_mapper.Map<Category>(value));
        }

        public async Task<IList<CategoryModel>> GetAllAsync()
        {
            return _mapper.Map<IList<CategoryModel>>(await _categoryRepository.GetAllAsync());
        }

        public async Task<CategoryModel> GetByIdAsync(string id)
        {
            return _mapper.Map<CategoryModel>(await _categoryRepository.GetByIdAsync(id));
        }

        public async Task<bool> UpdateAsync(CategoryUpdate value)
        {
            return await _categoryRepository.UpdateAsync(_mapper.Map<Category>(value));
        }
    }
}
