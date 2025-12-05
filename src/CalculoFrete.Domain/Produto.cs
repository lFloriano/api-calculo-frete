using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public Cep CepCentroDistribuicao { get; set; }

        //Demais propriedade foram omitidas por não serem relevantes ao calculo de frete
    }
}
