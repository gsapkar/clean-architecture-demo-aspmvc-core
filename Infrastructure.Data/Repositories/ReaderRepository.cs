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
    public class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        private readonly DbSet<Reader> _readers;
        public ReaderRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _readers = dbContext.Set<Reader>();

        }

        public IEnumerable<Reader> SearchByFullName(string searchTerm)
        {
            // AsEnumerable is bad for large data because it executes the query in memmory
            // and after that is applying the filters
            // https://www.nuget.org/packages/NinjaNye.SearchExtensions/ package can be used
            return _readers.AsEnumerable().Where(r =>
                    r.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                || r.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}
