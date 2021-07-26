using Data.MongoDb.Abstruct;
using Entities.Abstruct;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.MongoDb.Concreate
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;
        public BaseRepository()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("MongoExample");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }
        public async Task<bool> AddAsync(T value)
        {
            try
            {
                await _collection.InsertOneAsync(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T value)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x.Id, value.Id);
                await _collection.DeleteOneAsync(filter);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var result = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var result = await _collection.Find(x => true).ToListAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(T value)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x.Id, value.Id);
                await _collection.ReplaceOneAsync(filter, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
