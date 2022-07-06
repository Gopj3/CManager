using System;
namespace CManagerData.DataAccess
{
    public class GlobalDataAccess
    {
        public readonly UserCompanyDataAccess _userCompanyDataAccess;
        public readonly UserDataAccess _userDataAccess;
        public readonly CompanyDataAccess _companyDataAccess;
        public readonly LogoDataAccess _logoDataAccess;

        public GlobalDataAccess(string connectionString)
        {
            var context = new ApplicationDbContext(connectionString);
            _userCompanyDataAccess = new UserCompanyDataAccess(context);
            _userDataAccess = new UserDataAccess(context);
            _companyDataAccess = new CompanyDataAccess(context);
            _logoDataAccess = new LogoDataAccess(context);
        }
    }
}

