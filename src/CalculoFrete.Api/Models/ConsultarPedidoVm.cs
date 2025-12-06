using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Models
{
    public record ConsultarPedidoVm
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorFrete { get; set; }
        public Cep CepDestino { get; set; }
        public IReadOnlyCollection<ConsultarItemPedidoResumidoVm> Itens { get; set; }
    }
}
