using Project.LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.LibraryManagement.Core.Interfaces
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<IEnumerable<Book>> GetByIDAsync(int id);

        public void AddBook(Book book);

        public void DeleteBook(int id);

        public void UpdateBook(Book book);
    }
}
