using System;
namespace CManagerData.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt
        {
            get { return CreatedAt; }
            set { CreatedAt = DateTime.Now; }
        }
    }
}

