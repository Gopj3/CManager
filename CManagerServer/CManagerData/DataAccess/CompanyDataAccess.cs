using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.DataAccess
{
    public class CompanyDataAccess: BaseDataAccess<Company>
    {
        public CompanyDataAccess(ApplicationDbContext context): base(context)
        {
        }

        public async Task<Company> GetSingleByIdAsync(Guid id, CancellationToken token)
        {
            return await _appContext.Companies.Where(x => x.Id == id).SingleOrDefaultAsync(token);
        }

        public async Task<List<Company>> GetCompaniesByUserAsync(Guid userId, CancellationToken token)
        {
            return await _appContext.Companies
                .Include(x => x.UsersCompanies)
                .Where(x => x.UsersCompanies.Any(x => x.UserId == userId))
                .ToListAsync(token);
        }
    }
}

