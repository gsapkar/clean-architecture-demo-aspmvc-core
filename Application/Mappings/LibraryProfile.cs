using System;
using Application.ViewModels;
using Application.ViewModels.Reader;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class LibraryProfile:Profile
    {
        public LibraryProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Reader, ReaderViewModel>().ReverseMap();
        }
    }
}
