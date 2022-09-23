using System.Collections.Generic;
using CManagerData.Enums.Projects;

namespace CManagerData.Entities
{
    public class Project: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public List<ProjectUser> ProjectUsers { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}

