using System;
using System.Collections.Generic;
using Domain.Models.Base;
namespace Domain.Models
{
    public class Reader : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<BookReader> BookReaders { get; set; }
    }
}
