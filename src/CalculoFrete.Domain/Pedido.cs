namespace CalculoFrete.Domain
{
    public class Pedido
    {
        private List<ItemPedido> _items;

        public Pedido()
        {
            _items = new List<ItemPedido>();
        }

        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EnderecoEntregaId { get; set; }
        public EnderecoEntrega? EnderecoEntrega { get; set; }
        public IReadOnlyCollection<ItemPedido> Items => _items.AsReadOnly();

    }
}
