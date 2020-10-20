using System;
using Application.ViewModels.Reader;

namespace Application.Interfaces
{
    public interface IReaderService
    {
        ReaderListViewModel GetReaders();
        ReaderViewModel GetReaderById(Guid id);
        ReaderViewModel AddReader(ReaderViewModel readerRequest);
        void EditReader(ReaderViewModel readerRequest);
        ReaderListViewModel SearchByFullName(string searchTerm);
    }
}
