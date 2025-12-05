using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class ItemPedido
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public FreteNormal Frete { get; set; }
        public Produto Produto { get; set; }
    }
}
