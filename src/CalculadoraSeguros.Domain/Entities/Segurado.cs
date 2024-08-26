using CalculadoraSeguros.Shared.Entities;

namespace CalculadoraSeguros.Domain.Entities;

public class Segurado(string nome, string cpf, int idade) : Entity
{
    public string Nome { get; private set; } = nome;
    public string Cpf { get; private set; } = cpf;
    public int Idade { get; private set; } = idade;

    public ICollection<CalculoSeguro> CalculosSeguro { get; private set; }
}
