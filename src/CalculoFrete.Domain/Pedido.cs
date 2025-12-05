using CalculoFrete.Core.Domain;

namespace CalculoFrete.Domain
{
    public class Pedido : Entity
    {
        private List<ItemPedido> _items;

        public Pedido()
        {
            _items = new List<ItemPedido>();
        }

        public Guid ClienteId { get; private set; }
        public Guid EnderecoEntregaId { get; private set; }
        public EnderecoEntrega? EnderecoEntrega { get; private set; }
        public IReadOnlyCollection<ItemPedido> Items => _items.AsReadOnly();

    }
}
