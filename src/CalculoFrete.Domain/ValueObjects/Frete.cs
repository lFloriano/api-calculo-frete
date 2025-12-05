using CalculoFrete.Domain.Enums;

namespace CalculoFrete.Domain.ValueObjects
{
    public abstract record Frete
    {
        protected Frete(ModalidadeFrete modalidadeFrete, decimal pesoEmKg, decimal distanciaEmKm)
        {
            Validar(pesoEmKg, distanciaEmKm);
            ModalidadeFrete = modalidadeFrete;
            PesoEmKg = pesoEmKg;
            DistanciaEmKm = distanciaEmKm;
        }

        public ModalidadeFrete ModalidadeFrete { get; }
        public decimal PesoEmKg { get; }
        public decimal DistanciaEmKm { get; }
        protected abstract decimal TaxaFixa { get; }
        public abstract decimal Valor { get; }
        public abstract PrazoEntrega PrazoEntrega { get; }

        private void Validar(decimal pesoEmKg, decimal distanciaEmKm)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pesoEmKg, 0.000M);
            ArgumentOutOfRangeException.ThrowIfLessThan(distanciaEmKm, 0.000M);
        }
    }
}


