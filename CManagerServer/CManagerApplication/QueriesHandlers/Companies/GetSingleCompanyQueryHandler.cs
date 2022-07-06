using System;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Models.Results.Companies;
using CManagerApplication.Queries.Companies;
using CManagerData.DataAccess;
using MediatR;

namespace CManagerApplication.QueriesHandlers.Companies
{
    public class GetSingleCompanyQueryHandler: IRequestHandler<GetSingleCompanyQuery, SingleCompanyResult>
    {
        private readonly GlobalDataAccess _globalDataAccess;

        public GetSingleCompanyQueryHandler(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<SingleCompanyResult> Handle(GetSingleCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = await _globalDataAccess._companyDataAccess.GetSingleByIdAsync(request.Id, cancellationToken);
            
            return new SingleCompanyResult
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description
            };
        }
    }
}

