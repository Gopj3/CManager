namespace CManagerData.DataAccess
{
    public class GlobalDataAccess
    {
        public readonly UserDataAccess _userDataAccess;

        public GlobalDataAccess(string connectionString)
        {
            var context = new ApplicationDbContext(connectionString);
            _userDataAccess = new UserDataAccess(context);
        }
    }
}