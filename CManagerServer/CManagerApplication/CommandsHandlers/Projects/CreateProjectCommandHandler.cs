using System;
using System.Collections.Generic;
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
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly ILogger _logger;
        private readonly GlobalDataAccess _globalDataAccess;

        public CreateProjectCommandHandler(
            ILogger<CreateProjectCommandHandler> logger,
            GlobalDataAccess globalDataAccess
        )
        {
            _logger = logger;
            _globalDataAccess = globalDataAccess;
        }

        public async Task<Unit> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var user = await _globalDataAccess._userDataAccess.GetSingleByIdAsync(command.UserId, cancellationToken);

            if (user == null)
                throw new EntityNotFoundException($"User was not found with id {command.UserId}");

            var project = new Project
            {
                Title = command.Title,
                Description = command.Description,
                Status = ProjectStatusEnum.Active,
            };

            var projectUser = new ProjectUser
            {
                User = user,
                Project = project,
                UserRole = ProjectUserRoleEnum.Creator
            };

            project.ProjectUsers = new List<ProjectUser> { projectUser };
            await _globalDataAccess._projectDataAccess.AddAsync(project, cancellationToken);

            return Unit.Value;
        }
    }
}