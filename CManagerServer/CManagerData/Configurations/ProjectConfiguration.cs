using System;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.Configurations
{
    public static class ProjectConfiguration
    {
       public static void ApplyProjectConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Projects").HasKey(x => x.Id);
            modelBuilder.Entity<ProjectUser>().ToTable("ProjectUsers").HasKey(x => new { x.ProjectId, x.UserId });

            modelBuilder.Entity<ProjectUser>()
                .HasOne(bc => bc.User)
                .WithMany(bc => bc.PorjectUsers)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<ProjectUser>()
                .HasOne(bc => bc.Project)
                .WithMany(bc => bc.ProjectUsers)
                .HasForeignKey(bc => bc.ProjectId);
        }
    }
}

