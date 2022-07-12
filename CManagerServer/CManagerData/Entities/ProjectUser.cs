using System;
using CManagerData.Enums.Projects;

namespace CManagerData.Entities
{
    public class ProjectUser
    {
        public Guid UserId;
        public User User { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public ProjectUserRoleEnum UserRole { get; set; }
    }
}

