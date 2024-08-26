using Flunt.Notifications;

namespace CalculadoraSeguros.Shared.Commands;

public class CommandResult
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }

    public CommandResult(string mensagem, IReadOnlyCollection<Notification> erros)
    {
        Sucesso = false;
        Mensagem = mensagem;
        Dados = erros.SomenteMensagensDeErro();
    }

    public CommandResult(string mensagem, object dados)
    {
        Sucesso = true;
        Mensagem = mensagem;
        Dados = dados;
    }

    public CommandResult(string mensagem)
    {
        Sucesso = false;
        Mensagem = mensagem;
    }
}
