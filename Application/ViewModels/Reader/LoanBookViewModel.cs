using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.ViewModels.Reader
{
    public class LoanBookViewModel
    {
        public ReaderViewModel Reader { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; } = Enumerable.Empty<BookViewModel>();
    }
}
