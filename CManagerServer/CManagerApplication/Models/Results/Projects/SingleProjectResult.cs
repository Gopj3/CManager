using System;
using System.Collections.Generic;
using CManagerApplication.Models.Results.ProjectUsers;

namespace CManagerApplication.Models.Results.Projects
{
    public class SingleProjectResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SingleProjectUserResult> ProjectUsers { get; set; }
    }
}