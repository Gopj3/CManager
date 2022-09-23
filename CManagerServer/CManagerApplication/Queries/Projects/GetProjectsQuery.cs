using System;
using System.Collections.Generic;
using CManagerApplication.Models.Results.Projects;
using MediatR;

namespace CManagerApplication.Queries.Projects
{
    public class GetProjectsQuery: IRequest<List<SingleProjectResult>>
    {
        public GetProjectsQuery()
        {
        }

        public GetProjectsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}