namespace Flunt.Notifications;

public static class NotifiableExtends
{
    public static IReadOnlyCollection<string> SomenteMensagensDeErro(this IReadOnlyCollection<Notification> notificacoes)
    {
        var erros = new List<string>();
        foreach (var notificacao in notificacoes)
            erros.Add(notificacao.Message);

        return erros;
    }
}
