﻿using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

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
            var booksViewModel = _mapper.Map<IEnumerable<BookViewModel>>(_bookRepository.GetAll());
            return new BookListViewModel()
            {
                Books = booksViewModel
            };
        }

        public BookViewModel GetBookById(Guid id)
        {
            var bookVm = _mapper.Map<BookViewModel>(_bookRepository.GetById(id));

            return bookVm;
        }


        public BookViewModel AddBook(BookViewModel bookRequest)
        {
            var book = _mapper.Map<Book>(bookRequest);

            var addedBook = _bookRepository.Add(book);

            return _mapper.Map<BookViewModel>(addedBook);
        }

        

        public void EditBook(BookViewModel bookRequest)
        {
            var book = _mapper.Map<Book>(bookRequest);

            _bookRepository.Update(book);
        }

        public BookListViewModel FullTextSearch(string searchTerm)
        {
            var booksVm = new List<BookViewModel>();

            var books = string.IsNullOrEmpty(searchTerm) ?
                _bookRepository.GetAll() : _bookRepository.FullTextSearch(searchTerm).ToList();

            if (books != null && books.Any())
            {
                booksVm = _mapper.Map<List<BookViewModel>>(books);
            }

            return new BookListViewModel()
            {
                Books = booksVm
            };
        }
    }
}
