using AspNetCoreLearning.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreLearning.Database
{
    public class BookRepository
    {
        private readonly IMongoCollection<Book> books;

        public BookRepository(BookStoreDatabaseSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            books = database.GetCollection<Book>("Books");
        }

        public Book Create(Book book)
        {
            var created = new Book
            {
                Name = book.Name,
                Price = book.Price,
            };

            books.InsertOne(created);
            return created;
        }

        public List<Book> Find() =>
            books.Find((book) => true).ToList();

        public Book FindById(string id) =>
            books.Find(book => book.Id == id).SingleOrDefault();

        public void Update(Book Book) =>
            books.ReplaceOne(book => book.Id == Book.Id, Book);

        public void Delete(string id) =>
            books.DeleteOne(book => book.Id == id);
    }
}
