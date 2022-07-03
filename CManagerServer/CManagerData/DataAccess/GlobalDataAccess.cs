using System;
namespace CManagerData.DataAccess
{
    public class GlobalDataAccess
    {
        public readonly UserCompanyDataAccess _userCompanyDataAccess;
        public readonly UserDataAccess _userDataAccess;
        public readonly CompanyDataAccess _companyDataAccess;

        public GlobalDataAccess(ApplicationDbContext context)
        {
            _userCompanyDataAccess = new UserCompanyDataAccess(context);
            _userDataAccess = new UserDataAccess(context);
            _companyDataAccess = new CompanyDataAccess(context);
        }
    }
}

