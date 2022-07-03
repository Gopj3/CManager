using System;
using CManagerData.Entities;

namespace CManagerData.DataAccess
{
    public class CompanyDataAccess: BaseDataAccess<Company>
    {
        public CompanyDataAccess(ApplicationDbContext context): base(context)
        {
        }
    }
}

