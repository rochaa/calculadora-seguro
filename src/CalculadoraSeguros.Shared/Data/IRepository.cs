using CalculadoraSeguros.Shared.Entities;

namespace CalculadoraSeguros.Shared.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
