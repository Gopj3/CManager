using System;
using System.Threading.Tasks;
using CManagerData.Entities;

namespace CManagerData.DataAccess
{
    public class UserCompanyDataAccess: BaseDataAccess<UserCompany>
    {
        public UserCompanyDataAccess(ApplicationDbContext context): base(context) 
        {
        }
    }
}

