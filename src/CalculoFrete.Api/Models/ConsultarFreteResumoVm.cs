using CalculoFrete.Domain.Enums;
using Microsoft.OpenApi;

namespace CalculoFrete.Api.Models
{
    public record ConsultarFreteResumoVm
    {
        public ModalidadeFrete ModalidadeFrete { get; set; }
        public string? DescricaoFrete => ModalidadeFrete.GetDisplayName();
        public decimal Valor { get; set; }
        public int NumeroMinimoDias { get; set; }
        public int NumeroMaximoDias { get; set; }
        public DateOnly? DataAgendamento { get; set; }

    }
}
