using System;
namespace Domain.Models.Base
{
    public abstract class AuditableBaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime? LastModified { get; set; }
    }
}
