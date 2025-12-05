using CalculoFrete.Domain.Enums;

namespace CalculoFrete.Domain.ValueObjects
{
    public record FreteNormal : Frete
    {
        protected override decimal TaxaFixa => 5;

        public FreteNormal(decimal pesoEmKg, decimal distanciaEmKm) : base(ModalidadeFrete.Normal, pesoEmKg, distanciaEmKm) { }

        protected override void CalcularValor(decimal pesoEmKg, decimal distanciaemKm)
        {
            Valor = (pesoEmKg * 1.2M) + (distanciaemKm * 0.5M) + TaxaFixa;
        }

        protected override void CalcularPrazoEntrega()
        {
            PrazoEntrega = new PrazoEntrega(5, 8);
        }
    }
}


