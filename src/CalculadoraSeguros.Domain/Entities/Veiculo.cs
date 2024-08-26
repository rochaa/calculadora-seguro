using CalculadoraSeguros.Shared.Entities;

namespace CalculadoraSeguros.Domain.Entities
{
    public class Veiculo(string marca, string modelo, decimal valor) : Entity
    {
        public string Marca { get; private set; } = marca;
        public string Modelo { get; private set; } = modelo;
        public decimal Valor { get; private set; } = valor;

        public ICollection<CalculoSeguro> CalculosSeguro { get; private set; }
    }

}
