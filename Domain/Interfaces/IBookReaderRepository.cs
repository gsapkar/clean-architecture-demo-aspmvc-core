using System;
using Domain.Interfaces.Base;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBookReaderRepository : IBaseRepository<BookReader>
    {
        BookReader GetByReaderIdBookId(Guid readerId, Guid bookId);
    }
}
