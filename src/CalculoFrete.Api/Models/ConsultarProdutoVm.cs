using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Models
{
    public record ConsultarProdutoVm
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PesoEmKg { get; set; }
        public Cep CepCentroDistribuicao { get; set; }
    }
}
