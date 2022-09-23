using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CManagerApplication.Commands.Projects;
using CManagerApplication.Exceptions;
using CManagerData.DataAccess;
using CManagerData.Entities;
using CManagerData.Enums.Projects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CManagerApplication.CommandsHandlers.Projects
{
    public class AssignUserToProjectCommandHandler : IRequestHandler<AssignUserToProjectCommand>
    {
        private readonly GlobalDataAccess _globalDataAccess;
        private readonly ILogger _logger;

        public AssignUserToProjectCommandHandler(
            GlobalDataAccess globalDataAccess,
            ILogger<AssignUserToProjectCommandHandler> logger
        )
        {
            _globalDataAccess = globalDataAccess;
            _logger = logger;
        }

        public async Task<Unit> Handle(AssignUserToProjectCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _globalDataAccess._userDataAccess
                    .GetSingleByIdWithProjectId(command.AssignerId, command.ProjectId, cancellationToken);
                if (user == null)
                    throw new EntityNotFoundException($"User with id not found {command.AssignerId}");

                var projectAssignTo = user.PorjectUsers.SingleOrDefault(x => x.ProjectId == command.ProjectId);

                if (projectAssignTo?.UserRole != ProjectUserRoleEnum.Creator &&
                    projectAssignTo?.UserRole != ProjectUserRoleEnum.ProjectManager)
                    throw new AccessDeniedException($"User with id {command.AssignerId} not allowed to assign");

                var asignee =
                    await _globalDataAccess._userDataAccess.GetSingleByIdAsync(command.AssigneeId, cancellationToken);

                await _globalDataAccess._projectUsersDataAccess.AddAsync(
                    new ProjectUser
                    {
                        User = asignee,
                        Project = projectAssignTo.Project,
                        UserRole = command.Role
                    }, cancellationToken
                );

                return Unit.Value;
            }
            catch (Exception e)
            {
                _logger.LogError("Error while assign user to project {EMessage}", e.Message);
                throw e;
            }
        }
    }
}