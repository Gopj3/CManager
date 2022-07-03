using System;
using CManagerData.Configurations;
using CManagerData.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CManagerData
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, Guid>
    {
        private string _connection { get; set; }

        public DbSet<Company> Companies;
        public DbSet<UserCompany> UserCompanies;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public ApplicationDbContext(string connectionString)
        {
            _connection = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            UserCompanyConfiguration.ApplyConfig(modelBuilder);
        }
    }
}

