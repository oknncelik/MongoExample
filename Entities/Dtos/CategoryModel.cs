using Entities.Abstruct;

namespace Entities.Dtos
{
    public class CategoryModel : IDtos
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}