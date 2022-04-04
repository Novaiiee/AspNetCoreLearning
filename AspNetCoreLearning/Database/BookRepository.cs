using AspNetCoreLearning.Dtos;
using AspNetCoreLearning.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreLearning.Database
{
    public class BookRepository : IRepository<Book>
    {
        private readonly IMongoCollection<Book> books;
        private readonly FilterDefinitionBuilder<Book> filter;

        public BookRepository(BookStoreDatabaseSettings settings, IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            books = database.GetCollection<Book>("Books");

            filter = new FilterDefinitionBuilder<Book>();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var created = new Book
            {
                Name = book.Name,
                Price = book.Price,
            };

            await books.InsertOneAsync(created);
            return created;
        }

        public async Task<List<Book>> FindAsync() =>
            (await books.FindAsync(new BsonDocument())).ToList();

        public async Task<Book> FindByIdAsync(Guid id) =>
            (await books.FindAsync(filter.Eq(b => b.Id, id))).SingleOrDefault();

        public async Task UpdateAsync(Book Book) =>
            await books.ReplaceOneAsync(filter.Eq(b => b.Id.ToString(), Book.Id.ToString()), Book);

        public async Task DeleteAsync(Guid id) =>
            await books.DeleteOneAsync(filter.Eq(b => b.Id, id));
    }
}
