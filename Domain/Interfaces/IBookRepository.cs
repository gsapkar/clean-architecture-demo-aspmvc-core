using System;
using System.Collections.Generic;
using Domain.Interfaces.Base;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBookRepository: IBaseRepository<Book>
    {
        Book GetByISBN(string isbn);
    }
}
