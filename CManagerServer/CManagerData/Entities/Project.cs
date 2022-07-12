using System.Collections.Generic;
using CManagerData.Enums.Projects;

namespace CManagerData.Entities
{
    public class Project: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public List<ProjectUser> ProjectUsers = new List<ProjectUser>();
        public List<ProjectTask> ProjectTasks = new List<ProjectTask>();

    }
}

