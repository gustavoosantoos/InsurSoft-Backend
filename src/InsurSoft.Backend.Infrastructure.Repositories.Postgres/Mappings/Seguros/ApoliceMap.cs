using InsurSoft.Backend.Shared.Domain.Entities.Seguros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InsurSoft.Backend.Infrastructure.Repositories.Postgres.Mappings.Seguros
{
    public class ApoliceMap : IEntityTypeConfiguration<Apolice>
    {
        public void Configure(EntityTypeBuilder<Apolice> builder)
        {
            builder.ToTable("apolices");
            builder.HasKey(a => a.Codigo);

            builder.Property(a => a.Codigo).HasColumnName("codigo");

            builder.OwnsOne(a => a.NumeroApolice, numero =>
            {
                numero.Property(n => n.Numero).HasColumnName("numero_apolice");
            });

            builder.OwnsOne(a => a.Vigencia, vigencia =>
            {
                vigencia.Property(n => n.Inicio).HasColumnName("inicio_vigencia");
                vigencia.Property(n => n.Final).HasColumnName("final_vigencia");
            });

            builder.OwnsOne(a => a.PremioLiquido, premioLiquido =>
            {
                premioLiquido.Property(p => p.Valor).HasColumnName("premio_liquido");
            });

            builder.OwnsOne(a => a.PremioTotal, premioTotal =>
            {
                premioTotal.Property(p => p.Valor).HasColumnName("premio_total");
            });

            builder
                .HasOne(a => a.Segurado)
                .WithMany(s => s.Apolices)
                .HasForeignKey(a => a.CodigoSegurado)
                .HasConstraintName("fk_segurado_apolice");

            builder.Property(a => a.CodigoSegurado).HasColumnName("codigo_segurado");

            builder.Property(a => a.Apagado).HasColumnName("apagado");
        }
    }
}
