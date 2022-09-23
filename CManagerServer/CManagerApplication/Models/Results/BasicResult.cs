using System;

namespace CManagerApplication.Models.Results
{
    public abstract class BasicResult
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}