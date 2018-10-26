using InsurSoft.Backend.Infra.Repository.PostgreSQL.Mappings.Segurados;
using InsurSoft.Backend.Infra.Shared.Config;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Infra.Repository.PostgreSQL.Context
{
    public class InsurSoftContext : DbContext
    {
        public DbSet<Segurado> Segurados { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeguradoMap());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DatabaseConfig.ConnectionStringPostgreSQL);
        }
    }
}
