using System;
using System.Collections.Generic;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Book:AuditableBaseEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public int InStock { get; set; }

        public ICollection<BookReader> BookReaders { get; set; }
    }
}
