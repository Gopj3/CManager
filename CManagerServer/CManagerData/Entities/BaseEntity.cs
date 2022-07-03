using System;
namespace CManagerData.Entities
{
    public class BaseEntity
    {
        public Guid Id = Guid.NewGuid();
        public DateTime CreatedAt = DateTime.Now;
    }
}

