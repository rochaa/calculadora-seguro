using CalculadoraSeguros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraSeguros.Infra.Data.Mappings;

public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("Veiculo").HasKey(c => c.Id);
        builder.Property(v => v.Marca).HasColumnType("VARCHAR(100)").IsRequired());
        builder.Property(v => v.Modelo).HasColumnType("VARCHAR(100)").IsRequired();
        builder.Property(v => v.Valor).HasColumnType("DECIMAL(18,2)").IsRequired();
    }
}
