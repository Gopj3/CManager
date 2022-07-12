using System;
using System.ComponentModel.DataAnnotations;

namespace CManagerData.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id = Guid.NewGuid();

        public DateTime CreatedAt = DateTime.Now;
    }
}

