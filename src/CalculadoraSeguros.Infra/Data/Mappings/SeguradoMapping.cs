using CalculadoraSeguros.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraSeguros.Infra.Data.Mappings;

public class SeguradoMapping : IEntityTypeConfiguration<Segurado>
{
    public void Configure(EntityTypeBuilder<Segurado> builder)
    {
        builder.ToTable("Segurado").HasKey(c => c.Id);
        builder.Property(s => s.Nome).HasColumnType("VARCHAR(70)").IsRequired();
        builder.Property(s => s.Cpf).HasColumnType("VARCHAR(11)").IsRequired();
        builder.Property(s => s.Idade).IsRequired();
    }
}
