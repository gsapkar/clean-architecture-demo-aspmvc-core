using System;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
