using CalculoFrete.Core.Data;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        readonly IRepository<Pedido> _pedidoRepository;
        readonly IFreteService _freteService;

        public PedidoService(IRepository<Pedido> pedidoRepository, IFreteService freteService)
        {
            _pedidoRepository = pedidoRepository;
            _freteService = freteService;
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

        public async Task<Pedido> Atualizar(Guid id, Cep novoCep)
        {
            var pedido = await _pedidoRepository.ObterPorIdAsync(id) ??
                throw new InvalidOperationException("Pedido não encontrado para atualização");

            pedido.AtualizarCepEntrega(novoCep);
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

        public async Task<IEnumerable<ItemPedido>> CalcularFreteDoPedido(Pedido pedido)
        {
            foreach (var item in pedido.Itens)
            {
                var distanciaEmKm = await _freteService.CalcularDistanciaEmKm(pedido.CepDestino, item.Produto.CepCentroDistribuicao);
                item.CalcularFrete(distanciaEmKm, item.Produto.Peso, item.DataAgendamento);
            }

            return pedido.Itens;
        }
    }
}
