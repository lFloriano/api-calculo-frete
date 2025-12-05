namespace CalculoFrete.Domain.Services
{
    public interface IPedidoService
    {
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Pedido>> ObterTodosAsync();
        Task<Pedido> Adicionar(Pedido pedido);
        Task<Pedido> Atualizar(Pedido pedido);
        Task Remover(Guid id);
    }
}
