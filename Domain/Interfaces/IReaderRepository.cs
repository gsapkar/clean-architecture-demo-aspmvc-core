using System;
using System.Collections.Generic;
using Domain.Interfaces.Base;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReaderRepository : IBaseRepository<Reader>
    {
        IEnumerable<Reader> SearchByFullName(string searchTerm);
        Reader GetReaderWithLoanedBooks(Guid id);
    }
}
