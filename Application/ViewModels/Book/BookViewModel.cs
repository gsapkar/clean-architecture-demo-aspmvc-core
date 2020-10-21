using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BookViewModel
    {
        //   ADD MODEL VALIDATION
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Display(Name = "In Stock")]
        public int InStock { get; set; }
    }
}
