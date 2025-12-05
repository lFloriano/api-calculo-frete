using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class EnderecoEntrega
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Cep Cep { get; set; }
    }
}
