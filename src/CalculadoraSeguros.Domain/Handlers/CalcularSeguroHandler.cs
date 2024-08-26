using CalculadoraSeguros.Domain.Commands;
using CalculadoraSeguros.Domain.Entities;
using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Shared.Commands;

namespace CalculadoraSeguros.Domain.Handlers;

public class CalcularSeguroHandler(
    ICalculoSeguroRepository calculoSeguroRepository) : ICommandHandler<CalcularSeguroCommand>
{
    public async Task<CommandResult> Handle(CalcularSeguroCommand command, CancellationToken ct = default)
    {
        command.Validar();
        if (!command.IsValid)
            return new CommandResult("Dados para calcular o seguro inválido", command.Notifications);

        var calculoSeguro = new CalculoSeguro(command.Nome, command.Cpf, command.Idade, command.Marca, command.Modelo, command.Valor);

        calculoSeguroRepository.AdicionarSegurado(calculoSeguro.se);
        calculoSeguroRepository.AdicionarCalculoSeguro(calculoSeguro);
        calculoSeguroRepository.AdicionarCalculoSeguro(calculoSeguro);

        await calculoSeguroRepository.UnitOfWork.Commit();

        return new CommandResult("Calculo do segurdo realizado com sucesso.", calculoSeguro);
    }
}
