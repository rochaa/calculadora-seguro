namespace CalculadoraSeguros.Shared.Data;

public interface IUnitOfWork
{
    Task<int> Commit();
}
