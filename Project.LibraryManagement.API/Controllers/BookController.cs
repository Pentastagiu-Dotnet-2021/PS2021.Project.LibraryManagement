using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.LibraryManagement.Core.Entities;
using Project.LibraryManagement.Services.Dtos;
using Project.LibraryManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.LibraryManagement.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookDto>>> GetBooksAsync()
        {
            var result = await _bookService.GetBooksAsync();
            _logger.LogInformation("Books are retrieved successfully. Books count: {@count}", result.Count());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<BookDto>>> GetByIDAsync(int id)
        {
            var result = await _bookService.GetByIDAsync(id);
            _logger.LogInformation("Book is retrieved successfully.");
            return Ok(result);
        }

        [HttpPost]
        public Task Post(Book book)
        {
            _bookService.AddBook(book);
            _logger.LogInformation("Book was added successfully.");
            return Task.CompletedTask;
        }

        [HttpPut("{id}")]
        public Task Put(Book book)
        {
            _bookService.UpdateBook(book);
            _logger.LogInformation("Book's information was updated successfully.");
            return Task.CompletedTask;
        }

        [HttpDelete]
        public Task Delete(int id)
        {
            _bookService.DeleteBook(id);
            _logger.LogInformation("Book was deleted successfully.");
            return Task.CompletedTask;
        }
    }
}
