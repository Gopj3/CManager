using System;
using System.Collections.Generic;
using CManagerApplication.Models.Results.Companies;
using CManagerData.Entities;
using MediatR;

namespace CManagerApplication.Queries.Companies
{
    public class GetUserCompaniesListQuery: IRequest<List<SingleCompanyResult>>
    {
        public Guid UserId { get; set; }
    }
}

