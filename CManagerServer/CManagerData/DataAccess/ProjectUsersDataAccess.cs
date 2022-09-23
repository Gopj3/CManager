using CManagerData.Entities;

namespace CManagerData.DataAccess
{
    public class ProjectUsersDataAccess : BaseDataAccess<ProjectUser>
    {
        public ProjectUsersDataAccess(ApplicationDbContext context) : base(context)
        {
        }
    }
}