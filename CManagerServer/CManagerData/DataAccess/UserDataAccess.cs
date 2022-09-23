using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.DataAccess
{
    public class UserDataAccess : BaseDataAccess<User>
    {
        public UserDataAccess(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetSingleByIdAsync(Guid id, CancellationToken token)
        {
            return await _appContext.Users.SingleOrDefaultAsync(x => x.Id == id, token);
        }

        public async Task<User> GetSingleByIdWithProjects(Guid id, CancellationToken token)
        {
            return await _appContext.Users
                .Include(x => x.PorjectUsers)
                .ThenInclude(x => x.Project)
                .SingleOrDefaultAsync(x => x.Id == id, token);
        }

        public async Task<User> GetSingleByIdWithProjectId(Guid id, Guid projectId, CancellationToken token)
        {
            return await _appContext.Users
                .Include(x => x.PorjectUsers.Where(p => p.ProjectId == projectId))
                .ThenInclude(x => x.Project)
                .SingleOrDefaultAsync(x => x.Id == id, token);
        }
    }
}