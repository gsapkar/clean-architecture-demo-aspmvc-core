using System;
using System.Collections.Generic;
using Domain.Models;

namespace Application.ViewModels
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
