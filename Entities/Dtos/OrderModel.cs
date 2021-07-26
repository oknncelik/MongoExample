using Entities.Abstruct;

namespace Entities.Dtos
{
    public class OrderModel : IDtos
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}