using CalculadoraSeguros.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace CalculadoraSeguros.Domain.Commands;

public class CalcularSeguroCommand(string nome, string cpf, int idade, decimal valor, string marca, string modelo) : Command
{
    public string Nome { get; set; } = nome;
    public string Cpf { get; set; } = cpf;
    public int Idade { get; set; } = idade;
    public decimal Valor { get; set; } = valor;
    public string Marca { get; set; } = marca;
    public string Modelo { get; set; } = modelo;

    public override void Validar()
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome precisa ser informado.")
            .IsGreaterOrEqualsThan(Nome, 3, nameof(Nome), "Nome precisa ter mais de 3 caracteres.")
            .IsLowerOrEqualsThan(Nome, 60, nameof(Nome), "Maximo de 60 caracteres para o nome.")
            .IsNotNullOrEmpty(Cpf, nameof(Cpf), "Cpf precisa ser informado.")
            .IsGreaterOrEqualsThan(Idade, 18, nameof(Nome), "Idade precisa ser informada.")
            .IsGreaterThan(Valor, 0, nameof(Nome), "Valor precisa ser informado.")
            .IsNotNullOrEmpty(Marca, nameof(Marca), "Marca precisa ser informada.")
            .IsNotNullOrEmpty(Modelo, nameof(Modelo), "Modelo precisa ser informado.")
            );
    }
}
