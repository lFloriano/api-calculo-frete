using CalculoFrete.Domain.Enums;

namespace CalculoFrete.Domain.ValueObjects
{
    public abstract record Frete
    {
        protected Frete(ModalidadeFrete modalidadeFrete, decimal pesoEmKg, decimal distanciaEmKm)
        {
            Validar(pesoEmKg, distanciaEmKm);

            ModalidadeFrete = modalidadeFrete;
            CalcularValor(pesoEmKg, distanciaEmKm);
            CalcularPrazoEntrega();
        }

        protected abstract decimal TaxaFixa { get; }
        public ModalidadeFrete ModalidadeFrete { get; }
        public decimal Valor { get; protected set; }
        public PrazoEntrega PrazoEntrega { get; protected set; }

        protected abstract void CalcularValor(decimal pesoEmKg, decimal distanciaemKm);
        protected abstract void CalcularPrazoEntrega();

        private void Validar(decimal pesoEmKg, decimal distanciaEmKm)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pesoEmKg, 0.000M);
            ArgumentOutOfRangeException.ThrowIfLessThan(distanciaEmKm, 0.000M);
        }
    }
}


