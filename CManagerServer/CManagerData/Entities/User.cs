using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CManagerData.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<UserCompany> UsersCompanies = new List<UserCompany>();
        public List<ProjectUser> PorjectUsers = new List<ProjectUser>();
    }
}

