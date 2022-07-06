using System;
using CManagerData.Entities;

namespace CManagerData.DataAccess
{
    public class LogoDataAccess: BaseDataAccess<Logo>
    {
        public LogoDataAccess(ApplicationDbContext context): base(context)
        {
        }
    }
}

