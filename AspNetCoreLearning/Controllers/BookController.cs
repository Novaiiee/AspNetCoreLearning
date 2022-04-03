using AspNetCoreLearning.Database;
using AspNetCoreLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreLearning.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly BookRepository repository;

        public BookController(ILogger<BookController> logger, BookRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return repository.Find();
        }

        [HttpGet("{id}")]
        public Book GetBookById(string id)
        {
            return repository.FindById(id);
        }

        [HttpPost]
        public Book Create(Book book)
        {
            repository.Create(book);
            return book;
        }
    }
}
