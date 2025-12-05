using CalculoFrete.Core.Data;

namespace CalculoFrete.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        readonly IRepository<Pedido> _pedidoRepository;

        public PedidoService(IRepository<Pedido> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> Adicionar(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            var pedidoJaExiste = await _pedidoRepository.ObterPorIdAsync(pedido.Id) != null;

            if (pedidoJaExiste)
                throw new InvalidOperationException("O pedido já existe no sistema");

            await _pedidoRepository.Adicionar(pedido);
            return pedido;
        }

        public async Task<Pedido> Atualizar(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido));

            var pedidoOriginal = await _pedidoRepository.ObterPorIdAsync(pedido.Id) ??
                throw new InvalidOperationException("Pedido não encontrado para atualização");

            await _pedidoRepository.Atualizar(pedido);
            return pedido;
        }

        public async Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            return await _pedidoRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodosAsync()
        {
            return await _pedidoRepository.ObterTodosAsync();
        }

        public async Task Remover(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id) ??
                throw new InvalidOperationException("Pedido não encontrado para exclusão");

            await _pedidoRepository.Remover(pedido);
        }
    }
}
