using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Context
{
    public class LibraryDbContextSeed
    {
        public static async Task SeedAsync(LibraryDbContext libraryDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // NOTE : Only run this if using a real database
                libraryDbContext.Database.Migrate();
                libraryDbContext.Database.EnsureCreated();

                // seed Books
                await SeedCategoriesAsync(libraryDbContext);
                
                
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<LibraryDbContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(libraryDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task SeedCategoriesAsync(LibraryDbContext libraryDbContext)
        {
            if (libraryDbContext.Books.Any())
                return;

            var books = new List<Book>()
            {
                new Book() { Name = "The Lord of the Rings", AuthorName="J. R. R. Tolkien", ISBN="99921-58-10-7"}, // 1
                new Book() { Name = "The Da Vinci Code", AuthorName="Dan Brown", ISBN="0-385-50420-9"}, //2
                new Book() { Name = "Angels & Demons", AuthorName="Dan Brown", ISBN="0-671-02735-2"}, // 3
            };

            libraryDbContext.Books.AddRange(books);
            await libraryDbContext.SaveChangesAsync();
        }
    }
}
