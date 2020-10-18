using System;
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
    }
}
