using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Api.Models
{
    public record AdicionarPedidoVm
    {
        [Required(ErrorMessage = "A lista não pode ser nula")]
        [MinLength(1, ErrorMessage = "É necessário adicionar pelo menos 1 item ao pedido")]
        public IEnumerable<AdicionarPedidoItemPedidoVm>? ItensPedido { get; set; }

        [Required(ErrorMessage = "O ClienteId é obrigatório.")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O EnderecoEntregaId é obrigatório.")]
        public Guid EnderecoEntregaId { get; set; }
    }

}
