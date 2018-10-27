using InsurSoft.Backend.Infra.Repository.PostgreSQL.Mappings.Segurados;
using InsurSoft.Backend.Infra.Shared.Config;
using InsurSoft.Backend.Web.Segurados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

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
            optionsBuilder.UseLoggerFactory(
                new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) }));

            optionsBuilder.UseNpgsql(DatabaseConfig.ConnectionStringPostgreSQL);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
