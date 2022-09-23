using System;

namespace CManagerApplication.Models.Results.Companies
{
    public class SingleCompanyResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? UserRoleInCompany { get; set; }
    }
}

