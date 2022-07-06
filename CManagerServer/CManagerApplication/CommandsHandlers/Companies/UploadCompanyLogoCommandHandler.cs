using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Commands.Companies;
using CManagerApplication.Exceptions;
using CManagerData.DataAccess;
using CManagerData.Entities;
using CManagerData.Enums.Companies;
using MediatR;

namespace CManagerApplication.CommandsHandlers.Companies
{
    public class UploadCompanyLogoCommandHandler: IRequestHandler<UploadCompanyLogoCommand>
    {
        private readonly GlobalDataAccess _globalDataAccess;

        public UploadCompanyLogoCommandHandler(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<Unit> Handle(UploadCompanyLogoCommand command, CancellationToken cancellationToken)
        {
            var company = await _globalDataAccess._companyDataAccess.GetSingleByIdAsync(command.CompanyId, cancellationToken);

            if (company == null)
            {
                throw new EntityNotFoundException($"Company was not found with id {command.CompanyId}");
            }

            if (!company.UsersCompanies.Any(x => x.UserId == command.UserId && x.UserRole == UserCompanyRoleEnum.Owner))
            {
                throw new AccessDeniedException($"You are not granted to upload logo for company {company.Title}");
            }

            var fileName = Path.GetFileName(command.Logo.FileName);
            var fileExtension = Path.GetExtension(fileName);

            var logo = new Logo
            {
                Name = fileName,
                FileType = fileExtension
            };

            using var ms = new MemoryStream();
            command.Logo.CopyTo(ms);
            logo.DataFiles = ms.ToArray();

            await _globalDataAccess._logoDataAccess.AddAsync(logo, cancellationToken);

            company.LogoId = logo.Id;
            await _globalDataAccess._companyDataAccess.Update(company, cancellationToken);

            return Unit.Value;
        }
    }
}

