using System;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IBookService
    {
        BookListViewModel GetBooks();
        BookViewModel GetBookById(Guid id);
        BookViewModel AddBook(BookViewModel bookRequest);
        void EditBook(BookViewModel bookRequest);
    }
}
