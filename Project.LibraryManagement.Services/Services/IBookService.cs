using Project.LibraryManagement.Core.Entities;
using Project.LibraryManagement.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.LibraryManagement.Services.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<IEnumerable<BookDto>> GetByIDAsync(int id);

        void AddBook(Book book);

        void DeleteBook(int id);

        void UpdateBook(Book book);

    }

}
