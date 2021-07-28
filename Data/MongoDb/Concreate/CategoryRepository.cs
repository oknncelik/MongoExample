using Data.MongoDb.Abstruct;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Concreate
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
    }
}