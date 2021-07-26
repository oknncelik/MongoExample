using Entities.Abstruct;

namespace Entities.Dtos
{
    public class OrderCreate : IDtos
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
