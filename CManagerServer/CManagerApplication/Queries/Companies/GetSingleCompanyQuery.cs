using System;
using CManagerApplication.Models.Results.Companies;
using MediatR;

namespace CManagerApplication.Queries.Companies
{
    public class GetSingleCompanyQuery: IRequest<SingleCompanyResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}

