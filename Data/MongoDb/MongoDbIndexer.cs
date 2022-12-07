using Entities;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Medialyzer.Data.MongoDb
{
    public class MongoDbIndexer : IHostedService
    {
        public IMongoDatabase database { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            database = client.GetDatabase("MongoExample");

            var category = database.GetCollection<Category>(typeof(Category).Name);
            var order = database.GetCollection<Order>(typeof(Order).Name);

            await category.Indexes.CreateOneAsync(new CreateIndexModel<Category>(Builders<Category>.IndexKeys.Descending(x => x.Name)));

            await order.Indexes.CreateOneAsync(new CreateIndexModel<Order>(Builders<Order>.IndexKeys.Descending(x => x.CategoryId)));
            await order.Indexes.CreateOneAsync(new CreateIndexModel<Order>(Builders<Order>.IndexKeys.Descending(x => x.Name)));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
