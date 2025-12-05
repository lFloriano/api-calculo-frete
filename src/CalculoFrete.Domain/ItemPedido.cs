using CalculoFrete.Core.Domain;
using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class ItemPedido : Entity
    {
        public ItemPedido(Guid produtoId, ModalidadeFrete modalidadeFrete)
        {
            ProdutoId = produtoId;
        }

        public Guid ProdutoId { get; private set; }
        public ModalidadeFrete ModalidadeFrete { get; private set; }
        public DateOnly? DataAgendamento { get; private set; }
        public Frete Frete { get; private set; }
        public Produto Produto { get; private set; }

        public void CalcularFrete(decimal distanciaEmKm, decimal pesoEmKg, DateOnly? dataAgendamento = null)
        {
            switch (ModalidadeFrete)
            {
                case ModalidadeFrete.Normal:
                    Frete = new FreteNormal(pesoEmKg, distanciaEmKm);
                    break;

                case ModalidadeFrete.Expresso:
                    Frete = new FreteExpresso(pesoEmKg, distanciaEmKm);
                    break;

                case ModalidadeFrete.Agendado:
                    Frete = new FreteAgendado(pesoEmKg, distanciaEmKm, dataAgendamento);
                    break;

                default:
                    throw new NotImplementedException($"Cálculo não implementado para a modalidade de frete {ModalidadeFrete.ToString()}");
            }
        }
    }
}
