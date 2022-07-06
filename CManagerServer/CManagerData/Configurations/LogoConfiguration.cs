using System;
using CManagerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CManagerData.Configurations
{
    public static class LogoConfiguration
    {
        public static void ApplyConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logo>().ToTable("Logos").HasKey(x => x.Id);
        }
    }
}

