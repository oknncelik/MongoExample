using AutoMapper;
using Business.Concreate;
using Business.Mapping;
using Data.MongoDb.Abstruct;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        Mock<ICategoryRepository> _categoryRepository;
        Mock<IOrderRepository> _orderRepository;
        IMapper _mapper;

        IList<Order> _orders;
        IList<Category> _categories;

        [TestInitialize]
        public void Load()
        {
            #region Mock Data
            _orders = new List<Order>()
            {
                new Order
                {
                    Id = "1",
                    Name = "Test 1",
                    Description = "Description 1",
                    CategoryId = "1"
                },
                new Order
                {
                    Id = "2",
                    Name = "Test 2",
                    Description = "Description 2",
                    CategoryId = "1"
                },
                new Order
                {
                    Id = "3",
                    Name = "Test 3",
                    Description = "Description 3",
                    CategoryId = "1"
                },
                new Order
                {
                    Id = "4",
                    Name = "Test 4",
                    Description = "Description 4",
                    CategoryId = "1"
                }
            };

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
            _orderRepository = new Mock<IOrderRepository>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApplicationMapingProfile()); //your automapperprofile 
            });
            _mapper = mockMapper.CreateMapper();

            _categoryRepository.Setup(x => x.GetAllAsync()).Returns(Task.Run(()=> _categories));
            _categoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>((id) => Task.Run(() => _categories.FirstOrDefault(x=> x.Id == id)));
            _orderRepository.Setup(x => x.GetAllAsync()).Returns(Task.Run(() => _orders));
            _orderRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>())).Returns<string>((id) => Task.Run(() => _orders.FirstOrDefault(x => x.Id == id)));
        }

        [TestMethod]
        public void GetAllAsync()
        {
            OrderService service = new OrderService(_categoryRepository.Object, _orderRepository.Object, _mapper);
            var result = service.GetAllAsync();
            Assert.AreEqual(4, result.Result?.Count);
        }

        [TestMethod]
        public void GetByIdAsync()
        {
            OrderService service = new OrderService(_categoryRepository.Object, _orderRepository.Object, _mapper);
            var result = service.GetByIdAsync("1");
            Assert.IsNotNull(result.Result);
        }
    }
}
