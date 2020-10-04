using System;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IBookService
    {
        BookViewModel GetBooks();
    }
}
