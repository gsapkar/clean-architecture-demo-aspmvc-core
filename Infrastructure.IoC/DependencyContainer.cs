using System;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReaderService, ReaderService>();


            //Domain.Interfaces | Infra.Data.Repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IBookReaderRepository, BookReaderRepository>();

        }
    }
}
