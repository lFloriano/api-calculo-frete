using CalculoFrete.Core.Domain;

namespace CalculoFrete.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ObterTodosAsync();
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(Guid id);
    }
}
