using System;
using CManagerData.Entities;
using MediatR;

namespace CManagerApplication.Queries.Companies
{
    public class GetCompanyLogoQuery: IRequest<Logo>
    {
        public Guid CompanyId { get; set; }
    }
}

