using System;
using System.Collections.Generic;
using Domain.Models;

namespace Application.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
