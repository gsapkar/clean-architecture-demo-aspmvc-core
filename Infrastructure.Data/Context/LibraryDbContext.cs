
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Infrastructure.Data.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BookReader> BookReaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookReader>()
                .HasOne(br => br.Book).WithMany(b => b.BookReaders).HasForeignKey(br => br.BookId);

            modelBuilder.Entity<BookReader>()
                .HasOne(br => br.Reader).WithMany(b => b.BookReaders).HasForeignKey(br => br.ReaderId);
        }

    }

   
}
