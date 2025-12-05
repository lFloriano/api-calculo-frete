using CalculoFrete.Core.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class Pedido : Entity
    {
        private List<ItemPedido> _items;

        public Pedido(Guid clienteId, Guid enderecoEntregaId)
        {
            _items = new List<ItemPedido>();
            ClienteId = clienteId;
        }

        public Guid ClienteId { get; private set; }
        public decimal ValorFrete => Itens.Sum(x => x.Frete.Valor);
        public Cep CepDestino { get; private set; }
        public IReadOnlyCollection<ItemPedido> Itens => _items.AsReadOnly();

        public void AtualizarCep(Cep novoCep)
        {
            CepDestino = novoCep ?? throw new ArgumentNullException(nameof(Cep));
        }

    }
}
