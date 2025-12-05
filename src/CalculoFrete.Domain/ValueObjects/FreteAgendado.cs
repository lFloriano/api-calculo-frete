using CalculoFrete.Domain.Enums;

namespace CalculoFrete.Domain.ValueObjects
{
    public record FreteAgendado : Frete
    {
        public FreteAgendado(
            decimal pesoEmKg,
            decimal distanciaEmKm,
            DateOnly dataAgendamento) : base(ModalidadeFrete.Agendado, pesoEmKg, distanciaEmKm)
        {
            ValidarData(dataAgendamento);
            DataAgendamento = dataAgendamento;
        }

        protected override decimal TaxaFixa => 7;
        protected DateOnly DataAgendamento { get; set; }

        public override PrazoEntrega PrazoEntrega
        {
            get
            {
                var numeroDiasParaEntrega = DataAgendamento.ToDateTime(TimeOnly.MinValue) - DateTime.Now.Date;
                return new PrazoEntrega(numeroDiasParaEntrega.Days, numeroDiasParaEntrega.Days);
            }
        }

        public override decimal Valor => (PesoEmKg * 1.5M) + (DistanciaEmKm * 0.6M) + TaxaFixa;

        private void ValidarData(DateOnly dataAgendamento)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(dataAgendamento, dataAtual, "Data do Agendamento");
        }
    }
}


