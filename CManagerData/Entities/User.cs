using System;
using Microsoft.AspNetCore.Identity;

namespace CManagerData.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}

