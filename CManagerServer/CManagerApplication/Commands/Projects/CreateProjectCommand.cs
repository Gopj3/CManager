using System;
using MediatR;

namespace CManagerApplication.Commands.Projects
{
    public class CreateProjectCommand: IRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}