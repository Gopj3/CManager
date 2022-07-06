using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CManagerApplication.Commands.Companies
{
    public class UploadCompanyLogoCommand: IRequest
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public IFormFile Logo { get; set; }
    }
}

