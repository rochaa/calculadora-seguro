using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraSeguros.Infra.Data
{
    public class CalculadoraSeguroContext(
        DbContextOptions<CalculadoraSeguroContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<CalculoSeguro> CalculosSeguro { get; set; }
        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CalculadoraSeguroContext).Assembly);
        }

        public async Task<int> Commit()
        {
            return await base.SaveChangesAsync();
        }
    }
}
