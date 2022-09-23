using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.Configurations
{
    public static class ProjectTaskConfiguration
    {
        public static void ApplyTasksConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>().ToTable("ProjectTasks").HasKey(x => x.Id);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Project)
                .WithMany(x => x.ProjectTasks)
                .HasForeignKey(x => x.ProjectId);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Assignee)
                .WithMany()
                .HasForeignKey(x => x.AssigneeId);
        }
    }
}

