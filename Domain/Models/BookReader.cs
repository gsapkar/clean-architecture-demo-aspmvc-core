using System;
using Domain.Models.Base;

namespace Domain.Models
{
    public class BookReader:AuditableBaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
