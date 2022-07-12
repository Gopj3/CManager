using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Models.Results.Companies;
using CManagerApplication.Queries.Companies;
using CManagerData.DataAccess;
using CManagerData.Entities;
using CManagerData.Enums.Companies;
using MediatR;

namespace CManagerApplication.QueriesHandlers.Companies
{
    public class GetUserCompaniesListQueryHandler: IRequestHandler<GetUserCompaniesListQuery, List<SingleCompanyResult>>
    {
        private readonly GlobalDataAccess _globalDataAccess;

        public GetUserCompaniesListQueryHandler(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<List<SingleCompanyResult>> Handle(GetUserCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var result = await _globalDataAccess._companyDataAccess.GetCompaniesByUserAsync(request.UserId, cancellationToken);

            return result.Select(el => new SingleCompanyResult
            {
                Id = el.Id,
                Description = el.Description,
                Title = el.Title,
                UserRoleInCompany = Enum.GetName(
                    typeof(UserCompanyRoleEnum),
                    el.UsersCompanies.SingleOrDefault(x => x.UserId == request.UserId).UserRole)
            }).ToList();
        }
    }
}

