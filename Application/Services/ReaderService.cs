using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels;
using Application.ViewModels.Reader;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ReaderService:IReaderService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookReaderRepository _bookReaderRepository;
        private readonly IMapper _mapper;

        public ReaderService(IReaderRepository readerRepository,
            IBookRepository bookRepository,
            IBookReaderRepository bookReaderRepository,
            IMapper mapper)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _bookReaderRepository = bookReaderRepository;
            _mapper = mapper;
        }

        public ReaderListViewModel GetReaders()
        {
            var readersDto = _mapper.Map<IEnumerable<ReaderViewModel>>(_readerRepository.GetAll());
            return new ReaderListViewModel()
            {
                Readers = readersDto
            };
        }

        public ReaderViewModel GetReaderById(Guid id)
        {
            var readerVm = _mapper.Map<ReaderViewModel>(_readerRepository.GetById(id));

            return readerVm;
        }


        public ReaderViewModel AddReader(ReaderViewModel readerRequest)
        {
            var reader = _mapper.Map<Reader>(readerRequest);

            var addedReader = _readerRepository.Add(reader);

            return _mapper.Map<ReaderViewModel>(addedReader);
        }



        public void EditReader(ReaderViewModel readerRequest)
        {
            var Reader = _mapper.Map<Reader>(readerRequest);

            _readerRepository.Update(Reader);
        }

        public ReaderListViewModel SearchByFullName(string searchTerm)
        {
            var readersVm = new List<ReaderViewModel>();

            var readers = string.IsNullOrEmpty(searchTerm) ?
                _readerRepository.GetAll() : _readerRepository.SearchByFullName(searchTerm).ToList();
            if (readers != null && readers.Any())
            {
                readersVm = _mapper.Map<List<ReaderViewModel>>(readers);
            }

            return new ReaderListViewModel()
            {
                Readers = readersVm
            };
        }

        public LoanBookViewModel GetReaderWithLoanedBooks(Guid id)
        {
            var loanBookViewModel = new LoanBookViewModel();

            var reader = _readerRepository.GetReaderWithLoanedBooks(id);

            var readerVm = _mapper.Map<ReaderViewModel>(reader);
            var booksVm = _mapper.Map<IEnumerable<BookViewModel>>(reader.BookReaders.Select(x=>x.Book));

            loanBookViewModel.Reader = readerVm;
            loanBookViewModel.Books = booksVm;

            return loanBookViewModel;
        }

        public void LoanBook(Guid readerId, Guid bookId)
        {
            // Loan Book to Reader
            _bookReaderRepository.Add(new BookReader()
            {
                BookId = bookId,
                ReaderId = readerId
            });
            
            // Update Book stock
            var book = _bookRepository.GetById(bookId);
            --book.InStock;
            _bookRepository.Update(book);
        }

        public void ReturnBook(Guid readerId, Guid bookId)
        {
            var bookreader = _bookReaderRepository.GetByReaderIdBookId(readerId, bookId);
            // Delete Book from Reader
            _bookReaderRepository.Delete(bookreader);

            // Update Book stock
            var book = _bookRepository.GetById(bookId);
            ++book.InStock;
            _bookRepository.Update(book);
        }
    }
}
