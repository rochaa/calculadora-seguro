using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraSeguros.Infra.Data.Repositories;

public class CalculoSeguroRepository(CalculadoraSeguroContext context) : ICalculoSeguroRepository
{
    public IUnitOfWork UnitOfWork => context;

    public void AdicionarSegurado(Segurado segurado)
    {
        context.Segurados.Add(segurado);
    }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        context.Veiculos.Add(veiculo);
    }

    public void AdicionarCalculoSeguro(CalculoSeguro calculoSeguro)
    {
        context.CalculosSeguro.Add(calculoSeguro);
    }

    public async Task<CalculoSeguro> ObterPorId(Guid id)
    {
        return await context.CalculosSeguro
            .Include(c => c.Segurado)
            .Include(c => c.Veiculo)
            .FirstOrDefaultAsync(c => c.Id == id); ;
    }

    public async Task<IEnumerable<CalculoSeguro>> ObterTodos()
    {
        return await context.CalculosSeguro
            .Include(c => c.Segurado)
            .Include(c => c.Veiculo)
            .ToListAsync();
    }

    public void Dispose()
    {
        context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
