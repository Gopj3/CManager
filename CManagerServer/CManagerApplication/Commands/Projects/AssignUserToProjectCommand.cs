using System;
using CManagerData.Enums.Projects;
using MediatR;

namespace CManagerApplication.Commands.Projects
{
    public class AssignUserToProjectCommand: IRequest
    {
        public Guid ProjectId { get; set; }
        public Guid AssignerId { get; set; }
        public Guid AssigneeId { get; set; }
        public ProjectUserRoleEnum Role { get; set; }
    }
}