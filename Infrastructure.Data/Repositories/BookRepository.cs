using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly DbSet<Book> _books;
        public BookRepository(LibraryDbContext dbContext) :base(dbContext)
        {
            _books = dbContext.Set<Book>();
               
        }

        public Book GetByISBN(string isbn)
        {
            return _books.FirstOrDefault(x => x.ISBN == isbn);
        }

        public IEnumerable<Book> FullTextSearch(string searchTerm)
        {
            // AsEnumerable is bad for large data because it executes the query in memmory
            // and after that is applying the filters
            // https://www.nuget.org/packages/NinjaNye.SearchExtensions/ package can be used
            return _books.AsEnumerable().Where(r =>
                    r.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                || r.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                || r.AuthorName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}
