using CalculadoraSeguros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalculadoraSeguros.Infra.Data.Mappings;

public class CalculoSeguroMapping : IEntityTypeConfiguration<CalculoSeguro>
{
    public void Configure(EntityTypeBuilder<CalculoSeguro> builder)
    {
        builder.ToTable("CalculoSeguro").HasKey(c => c.Id);
        builder.Property(c => c.SeguradoId);
        builder.Property(c => c.VeiculoId);
        builder.Property(c => c.TaxaRisco).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.PremioRisco).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.PremioPuro).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.PremioComercial).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.MargemSeguranca).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.Lucro).HasColumnType("DECIMAL(18,2)").IsRequired();
        builder.Property(c => c.ValorSeguro).HasColumnType("DECIMAL(18,2)").IsRequired();

        builder.HasOne(c => c.Segurado).WithMany(s => s.CalculosSeguro).HasForeignKey(c => c.SeguradoId).HasPrincipalKey(s => s.Id);
        builder.HasOne(c => c.Veiculo).WithMany(v => v.CalculosSeguro).HasForeignKey(c => c.VeiculoId).HasPrincipalKey(v => v.Id);
    }
}
