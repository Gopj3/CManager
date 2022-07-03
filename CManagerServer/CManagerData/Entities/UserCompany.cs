using System;
using CManagerData.Enums.Companies;

namespace CManagerData.Entities
{
    public class UserCompany
    {
        public Guid UserId;
        public User User { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public UserCompanyRoleEnum UserRole { get; set; }
    }
}

