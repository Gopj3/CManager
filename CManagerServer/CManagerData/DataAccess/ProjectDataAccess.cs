using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.DataAccess
{
    public class ProjectDataAccess : BaseDataAccess<Project>
    {
        public ProjectDataAccess(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Project>> GetListOfProjectsByUserId(Guid userId, CancellationToken cancellationToken)
        {
            return await _appContext.Projects
                .Include(x => x.ProjectUsers)
                .ThenInclude(x => x.User)
                .Where(x => x.ProjectUsers.Any(x => x != null && x.UserId == userId))
                .ToListAsync(cancellationToken);
        }
    }
}