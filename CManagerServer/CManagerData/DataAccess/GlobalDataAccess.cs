namespace CManagerData.DataAccess
{
    public class GlobalDataAccess
    {
        public readonly ProjectDataAccess _projectDataAccess;
        public readonly ProjectUsersDataAccess _projectUsersDataAccess;
        public readonly UserDataAccess _userDataAccess;


        public GlobalDataAccess(string connectionString)
        {
            var context = new ApplicationDbContext(connectionString);
            _userDataAccess = new UserDataAccess(context);
            _projectDataAccess = new ProjectDataAccess(context);
            _projectUsersDataAccess = new ProjectUsersDataAccess(context);
        }
    }
}