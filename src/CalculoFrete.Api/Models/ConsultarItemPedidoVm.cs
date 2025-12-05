using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Models
{
    public record ConsultarItemPedidoVm
    {
        public Guid ProdutoId { get; set; }
        public ModalidadeFrete ModalidadeFrete { get; set; }
        public DateOnly? DataAgendamento { get; set; }
        public Frete Frete { get; set; }
        public ConsultarProdutoVm Produto { get; set; }
    }
}
