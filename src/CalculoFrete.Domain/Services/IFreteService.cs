using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public interface IFreteService
    {
        public PrazoEntrega CalcularDistanciaEmKm(Cep cepOrigem, Cep cepDestino);
    }
}
