using System;
namespace Domain.Models.Base
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
