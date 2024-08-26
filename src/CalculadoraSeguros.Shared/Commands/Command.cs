using Flunt.Notifications;
using MediatR;

namespace CalculadoraSeguros.Shared.Commands;

public abstract class Command() : Notifiable<Notification>, IRequest<CommandResult>
{
    public abstract void Validar();
}
