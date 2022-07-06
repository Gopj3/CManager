using System;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Commands.Companies;
using CManagerApplication.Exceptions;
using CManagerApplication.Models.Dto.Companies;
using CManagerData.DataAccess;
using CManagerData.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CManagerApplication.CommandsHandlers.Companies
{
    public class CreateCompanyCommandHandler: IRequestHandler<CreateCompanyCommand, CompanyCreatedResult>
    {
        private readonly ILogger _logger;
        private readonly GlobalDataAccess _globalDataAccess;

        public CreateCompanyCommandHandler(
            GlobalDataAccess globalDataAccess,
            ILogger<CreateCompanyCommandHandler> logger
        )
        {
            _globalDataAccess = globalDataAccess;
            _logger = logger;
        }

        public async Task<CompanyCreatedResult> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var user = await _globalDataAccess._userDataAccess
                .GetSingleById(request.CreatorId, cancellationToken);

            if (user == null)
            {
                throw new EntityNotFoundException($"User was not found with id {request.CreatorId}");
            }

            try
            {
                var company = new Company
                {
                    Title = request.Title,
                    Description = request.Description,
                };

                company.UsersCompanies.Add(new UserCompany { Company = company, User = user });
                await _globalDataAccess._companyDataAccess.AddAsync(company, cancellationToken);

                return new CompanyCreatedResult{ Id = company.Id };
            } catch (Exception e)
            {
                _logger.LogError($"Error while company creation {e.Message} {e.InnerException}");
                throw e;
            } 
        }
    }
}

