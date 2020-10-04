using System;
using System.Collections.Generic;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public BookListViewModel GetBooks()
        {
            var booksDto = _mapper.Map<IEnumerable<BookDTO>>(_bookRepository.GetAll());
            return new BookListViewModel()
            {
                Books = booksDto
            };
        }
    }
}
