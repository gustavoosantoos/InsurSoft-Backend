using InsurSoft.Backend.Shared.DomainModel.SeguradosAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsurSoft.Backend.Infrastructure.Repositories.Postgres.Mappings.Segurados
{
    public class SeguradoMap : IEntityTypeConfiguration<Segurado>
    {
        public void Configure(EntityTypeBuilder<Segurado> builder)
        {
            builder.ToTable("segurados");

            builder.HasKey(b => b.Codigo);
            builder.Property(b => b.Codigo).HasColumnName("codigo");

            builder.OwnsOne(b => b.Nome, nome =>
            {
                nome.Property(n => n.Nome).HasColumnName("nome");
                nome.Property(n => n.Sobrenome).HasColumnName("sobrenome");
            });

            builder.OwnsOne(b => b.DataNascimento, data =>
            {
                data.Property(d => d.Data).HasColumnName("data_nascimento");
            });

            builder.Property(b => b.Apagado).HasColumnName("apagado");

            builder.HasQueryFilter(s => !s.Apagado);
        }
    }
}
