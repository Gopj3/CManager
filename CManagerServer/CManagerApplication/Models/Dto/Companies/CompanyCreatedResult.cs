using System;
using System.Collections.Generic;

namespace CManagerApplication.Models.Dto.Companies
{
    public class CompanyCreatedResult
    {
        public Guid Id { get; set; }
        public string Tilte { get; set; }
        public List<string>? Erorrs { get; set; }
    }
}

