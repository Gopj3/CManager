using System;
using System.Collections.Generic;

namespace CManagerData.Entities
{
    public class Company: BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<UserCompany> UsersCompanies = new List<UserCompany>();
        public Guid? LogoId { get; set; }
    }
}

