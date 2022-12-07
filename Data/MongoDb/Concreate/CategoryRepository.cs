using Data.MongoDb.Abstruct;
using Entities;
using Entities.Dtos;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.MongoDb.Concreate
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        /// <summary>
        /// Mongo Group By Example
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryCount>> GetDataSessions()
        {
            var collection = GetCollection<Category>();
            //var filter = Builders<Category>.Filter.And(
            //                Builders<EventRecord>.Filter.Where(x => x.WebsiteId == model.WebsiteId),
            //                Builders<EventRecord>.Filter.Where(x => x.CreationDateUtcMinute <= model.EndDate.GetDayEnd()),
            //                Builders<EventRecord>.Filter.Where(x => x.CreationDateUtcMinute >= model.StartDate.GetDayStart()));

            return await collection.Aggregate()
                        //.Match(filter)
                        .Group(x => x.Name,
                               n => new CategoryCount
                               {
                                   CategoryName = n.Key,
                                   OrderCount = n.Count()
                               })
                        .SortByDescending(x => x.CategoryName)
                        .ToListAsync();
        }

    }
}