using System;
namespace Application.ViewModels
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
    }
}
