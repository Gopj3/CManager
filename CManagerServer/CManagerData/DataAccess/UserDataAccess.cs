using System;
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
    }
}