using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Models.DTO.Mappers;
using CManagerApplication.Models.Results.Projects;
using CManagerApplication.Models.Results.ProjectUsers;
using CManagerApplication.Queries.Projects;
using CManagerData.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CManagerApplication.QueriesHandlers.Projects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<SingleProjectResult>>
    {
        private readonly GlobalDataAccess _globalDataAccess;
        private readonly ILogger _logger;

        public GetProjectsQueryHandler(
            ILogger<GetProjectsQueryHandler> logger,
            GlobalDataAccess globalDataAccess
        )
        {
            _logger = logger;
            _globalDataAccess = globalDataAccess;
        }

        public async Task<List<SingleProjectResult>> Handle(GetProjectsQuery request,
            CancellationToken cancellationToken)
        {
            var projects =
                await _globalDataAccess._projectDataAccess.GetListOfProjectsByUserId(request.UserId, cancellationToken);

            return projects.Select(x => new SingleProjectResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ProjectUsers = x.ProjectUsers
                    .Select(up => new SingleProjectUserResult
                    {
                        User = up.User.ToDto(),
                        Role = up.UserRole.ToString()
                    })
                    .ToList()
            }).ToList();
        }
    }
}