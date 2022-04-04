using AspNetCoreLearning.Database;
using AspNetCoreLearning.Dtos;
using AspNetCoreLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreLearning.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly IRepository<Book> repository;

        public BookController(ILogger<BookController> logger, IRepository<Book> repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<List<Book>> GetBooks()
        {
            return await repository.FindAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(Guid id)
        {
            Book book = await repository.FindByIdAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<Book> Create(Book book)
        {
            return await repository.CreateAsync(book);
        }
    }
}
