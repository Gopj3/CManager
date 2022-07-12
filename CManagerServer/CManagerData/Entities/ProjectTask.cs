using System;
using CManagerData.Enums.Tasks;

namespace CManagerData.Entities
{
    public class ProjectTask: BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid AssigneeId { get; set; }
        public User Assignee { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}

