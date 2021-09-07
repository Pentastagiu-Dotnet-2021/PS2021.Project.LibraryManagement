using Project.LibraryManagement.Core.Entities;
using Project.LibraryManagement.Core.Interfaces;
using Project.LibraryManagement.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Project.LibraryManagement.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BooksRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            string query = @"Select * from Books";
            return await _connectionFactory.GetConnection().QueryAsync<Book>(query);
        }

        public async Task<IEnumerable<Book>> GetByIDAsync(int id)
        {
            string query = @"select * from Books where Id = @id";
            return await _connectionFactory.GetConnection().QueryAsync<Book>(query, new { Id = id });
        }

        public async void AddBook(Book book)
        {
            string query = @"insert into Books(Title, Author, Publisher, Pages, Year, Language) values (@Title, @Author, @Publisher, @Pages, @Year, @Language)";
            await _connectionFactory.GetConnection().ExecuteAsync(query, book);
        }

        public async void DeleteBook(int id)
        {
            string query = @"delete from Books where Id = @id";
            await _connectionFactory.GetConnection().ExecuteAsync(query, new { Id = id });
        }

        public async void UpdateBook(Book book)
        {
            string query = @"update Books set Title=@Title, Author=@Author, Publisher=@Publisher, Pages=@Pages, Year=@Year, Language=@Language where Id = @id";
            await _connectionFactory.GetConnection().ExecuteAsync(query, book);
        }

    }
}
