using Project.LibraryManagement.Core.Entities;
using Project.LibraryManagement.Core.Interfaces;
using Project.LibraryManagement.Services.Dtos;
using Project.LibraryManagement.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _bookRepository;

        public BookService(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var booksDtos = books.Select(b => new BookDto
            {
                Title = b.Title,
                Author = b.Author,
                Publisher = b.Publisher,
                Pages = b.Pages,
                Year = b.Year,
                Language = b.Language,
                //ImageUri = b.ImageUri
            }).ToList();

            return booksDtos;
        }

        public async Task<IEnumerable<BookDto>> GetByIDAsync(int id)
        {
            var books = await _bookRepository.GetByIDAsync(id);
            var booksDtos = books.Select(b => new BookDto
            {
                Title = b.Title,
                Author = b.Author,
                Publisher = b.Publisher,
                Pages = b.Pages,
                Year = b.Year,
                Language = b.Language,
                //ImageUri = b.ImageUri
            }).ToList();

            return booksDtos;
        }

        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.DeleteBook(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }
    }
}
