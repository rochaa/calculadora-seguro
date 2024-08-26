using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Shared.Data;

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

    public void Dispose()
    {
        context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
