using AbstractionLayer.Repository.Interfaces;
using DataLayer.Mongo;
using Domain.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AbstractionLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _db;
        public BookRepository(IOptions<MongoSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _db = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Book>(options.Value.CollectionName);
        }
        public async Task<int> Create(Book item)
        {
            await _db.InsertOneAsync(item);
            return int.Parse(item.Id);
        }

        public async Task<IList<Book>> GetAll()
        {
            return await _db.Find(x => true).ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _db.Find(x => x.Id == id.ToString())
                .FirstOrDefaultAsync();
        }

        public async Task<Book> GetByName(string name)
        {
            return await _db.Find(x => x.Title == name)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Update(Book item)
        {

            var result = await _db.ReplaceOneAsync(x => x.Id == item.Id, item);
            int isOk = 0; 
            if (result.IsAcknowledged)
            {
                isOk = 1;
            }
            return isOk;
        }

        public async Task<int> Delete(int id)
        {

            var result = await _db.DeleteOneAsync(x => x.Id == id.ToString());
            
            int isOk = 0;
            if (result.IsAcknowledged)
            {
                isOk = 1;
            }
            return isOk;
        }
    }
}
