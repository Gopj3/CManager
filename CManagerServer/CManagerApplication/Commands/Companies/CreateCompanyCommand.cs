using System;
using CManagerData.Entities;
using MediatR;

namespace CManagerApplication.Commands.Companies
{
    public class CreateCompanyCommand: IRequest<Company>
    {
        public Guid CreatorId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}

