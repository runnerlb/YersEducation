using System;

namespace Yers.Service.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
    }
}