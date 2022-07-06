using System;
using CManagerApplication.Models.Dto.Companies;
using CManagerData.Entities;
using MediatR;

namespace CManagerApplication.Commands.Companies
{
    public class CreateCompanyCommand: IRequest<CompanyCreatedResult>
    {
        public Guid CreatorId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}

