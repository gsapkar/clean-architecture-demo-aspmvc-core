using System;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class BookReaderRepository : BaseRepository<BookReader>, IBookReaderRepository
    {
        private readonly DbSet<BookReader> _bookReaders;
        public BookReaderRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _bookReaders = dbContext.Set<BookReader>();

        }
    }
}
