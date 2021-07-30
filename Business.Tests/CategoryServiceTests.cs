using AutoMapper;
using Business.Concreate;
using Business.Mapping;
using Data.MongoDb.Abstruct;
using Entities;
using Entities.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Tests
{
    [TestClass]
    public class CategoryServiceTests
    {
        Mock<ICategoryRepository> _categoryRepository;
        IMapper _mapper;

        IList<Category> _categories;

        [TestInitialize]
        public void Load()
        {
            #region Mock Data
            _categories = new List<Category>()
            {
                new Category
                {
                    Id = "1",
                    Name = "Test 1",
                },
                new Category
                {
                    Id = "2",
                    Name = "Test 2",
                }
            };
            #endregion

            _categoryRepository = new Mock<ICategoryRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapingProfile()); //your automapperprofile 
            });
            _mapper = mockMapper.CreateMapper();

            _categoryRepository.Setup(x => x.GetAllAsync()).Returns(Task.Run(() => _categories));
            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>((id) => Task.Run(() => _categories.FirstOrDefault(x => x.Id == id)));
            _categoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns<Category>((order) => Task.Run(() => order));
            _categoryRepository.Setup(x => x.UpdateAsync(It.IsAny<Category>())).Returns<Category>((order) => Task.Run(() => order));
            _categoryRepository.Setup(x => x.DeleteAsync(It.IsAny<Category>())).Returns<bool>((order) => Task.Run(() => true));

        }

        [TestMethod]
        public void GetAllAsync()
        {
            CategoryService service = new CategoryService(_categoryRepository.Object, _mapper);
            var result = service.GetAllAsync();
            Assert.AreEqual(2, result.Result?.Count);
        }

        [TestMethod]
        public void GetByIdAsync()
        {
            CategoryService service = new CategoryService(_categoryRepository.Object, _mapper);
            var result = service.GetByIdAsync("1");
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void AddAsync()
        {
            CategoryService service = new CategoryService(_categoryRepository.Object, _mapper);
            var result = service.AddAsync(new CategoryCreate
            {
                Name = "Test 3",
            });
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void UpdateAsync()
        {
            CategoryService service = new CategoryService(_categoryRepository.Object, _mapper);
            var result = service.UpdateAsync(new CategoryUpdate
            {
                Id = "2",
                Name = "Test 4",
            });
            Assert.AreEqual("Test 4", result.Result.Name);
        }
    }
}
