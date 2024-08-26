using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Shared.Data;

namespace CalculadoraSeguros.Domain.Repositories;

public interface ICalculoSeguroRepository : IRepository<CalculoSeguro>
{
    void AdicionarSegurado(Segurado segurado);
    void AdicionarVeiculo(Veiculo veiculo);
    void AdicionarCalculoSeguro(CalculoSeguro calculoSeguro);
}
