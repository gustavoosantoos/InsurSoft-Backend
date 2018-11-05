using InsurSoft.Backend.Infrastructure.Config;
using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Mappings.Segurados;
using InsurSoft.Backend.Infrastructure.Repositories.Postgres.Mappings.Seguros;
using InsurSoft.Backend.Shared.Domain.Entities.Segurados;
using InsurSoft.Backend.Shared.Domain.Entities.Seguros;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace InsurSoft.Backend.Infrastructure.Repositories.Postgres.Context
{
    public class InsurSoftContext : DbContext
    {
        public DbSet<Segurado> Segurados { get; private set; }
        public DbSet<Apolice> Apolices { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeguradoMap());
            modelBuilder.ApplyConfiguration(new ApoliceMap());
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
