using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Exceptions;
using CManagerApplication.Queries.Companies;
using CManagerData.DataAccess;
using CManagerData.Entities;
using MediatR;

namespace CManagerApplication.QueriesHandlers.Companies
{
    public class GetCompanyLogoQueryHandler: IRequestHandler<GetCompanyLogoQuery, Logo>
    {
        private readonly GlobalDataAccess _globalDataAccess;

        public GetCompanyLogoQueryHandler(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<Logo> Handle(GetCompanyLogoQuery request, CancellationToken cancellationToken)
        {
            var company = await _globalDataAccess._companyDataAccess.GetSingleByPredicate(x => x.Id == request.CompanyId, cancellationToken);

            if (company == null)
            {
                throw new EntityNotFoundException($"Company not found with id {request.CompanyId}");
            }

           var logo = await _globalDataAccess._logoDataAccess.GetSingleByPredicate(x => x.Id == company.LogoId, cancellationToken);

           if (logo == null)
           {
                throw new EntityNotFoundException($"Logo not found for company with id {request.CompanyId}");
           }

            return logo;
        }
    }
}

