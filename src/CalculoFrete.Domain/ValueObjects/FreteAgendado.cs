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
            CalcularPrazoEntrega();
        }

        protected override decimal TaxaFixa => 7;
        protected DateOnly DataAgendamento { get; set; }

        protected override void CalcularPrazoEntrega()
        {
            var numeroDiasParaEntrega = DataAgendamento.ToDateTime(TimeOnly.MinValue) - DateTime.Now.Date;
            PrazoEntrega = new PrazoEntrega(numeroDiasParaEntrega.Days, numeroDiasParaEntrega.Days);
        }

        protected override void CalcularValor(decimal pesoEmKg, decimal distanciaemKm)
        {
            Valor = (pesoEmKg * 1.5M) + (distanciaemKm * 0.6M) + TaxaFixa;
        }

        private void ValidarData(DateOnly dataAgendamento)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(dataAgendamento, dataAtual, "Data do Agendamento");
        }
    }
}


