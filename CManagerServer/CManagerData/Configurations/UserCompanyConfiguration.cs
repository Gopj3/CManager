using System;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.Configurations
{
    public static class UserCompanyConfiguration
    {
        public static void ApplyConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Companies").HasKey(bc => bc.Id);
            modelBuilder.Entity<UserCompany>().ToTable("UserCompanies").HasKey(bc => new { bc.CompanyId, bc.UserId });
            modelBuilder.Entity<UserCompany>()
                .HasOne(bc => bc.Company)
                .WithMany(bc => bc.UsersCompanies)
                .HasForeignKey(bc => bc.CompanyId);
            modelBuilder.Entity<UserCompany>()
                .HasOne(bc => bc.User)
                .WithMany(bc => bc.UsersCompanies)
                .HasForeignKey(bc => bc.UserId);
        }
    }
}

