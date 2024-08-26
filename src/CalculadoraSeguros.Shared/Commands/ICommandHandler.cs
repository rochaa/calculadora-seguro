using MediatR;

namespace CalculadoraSeguros.Shared.Commands;

public interface ICommandHandler<T> : IRequestHandler<T, CommandResult> where T : Command { }
