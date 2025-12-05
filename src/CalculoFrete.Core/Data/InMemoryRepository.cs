using CalculoFrete.Core.Domain;

namespace CalculoFrete.Core.Data
{
    public class InMemoryRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly Dictionary<Guid, T> _storage = new();

        public void Adicionar(T entity)
        {
            _storage.Add(entity.Id, entity);
        }

        public void Atualizar(T entity)
        {
            _storage[entity.Id] = entity;
        }

        public Task<T?> ObterPorIdAsync(Guid id)
        {
            return Task.FromResult(_storage.TryGetValue(id, out var entity) ? entity : null);
        }

        public Task<IEnumerable<T>> ObterTodosAsync()
        {
            return Task.FromResult(_storage.Select(x => x.Value));
        }

        public void Remover(Guid id)
        {
            _storage.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
