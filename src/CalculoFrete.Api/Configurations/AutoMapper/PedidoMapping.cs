using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Configurations.AutoMapper
{
    public class PedidoMappings : Profile
    {
        public PedidoMappings()
        {
            // Domain -> viewmodel
            CreateMap<Pedido, ConsultarPedidoVm>();
            //CreateMap<ItemPedido, ConsultarItemPedidoVm>();
            CreateMap<Produto, ConsultarProdutoVm>();
            CreateMap<Frete, ConsultarFreteVm>();
            CreateMap<PrazoEntrega, ConsultarPrazoEntregaVm>();
            CreateMap<ItemPedido, ConsultarItemPedidoResumidoVm>()
                .ForMember(dest => dest.Frete, opt => opt.MapFrom(src => new ConsultarFreteResumoVm()
                {
                    DataAgendamento = src.DataAgendamento,
                    ModalidadeFrete = src.ModalidadeFrete,
                    NumeroMinimoDias = src.Frete.PrazoEntrega.NumeroMinimoDias,
                    NumeroMaximoDias = src.Frete.PrazoEntrega.NumeroMaximoDias,
                    Valor = src.Frete.Valor
                }));

            // Viewmodel -> domain
            CreateMap<AdicionarPedidoVm, Pedido>();
            CreateMap<AdicionarPedidoItemPedidoVm, ItemPedido>();
            CreateMap<AdicionarPedidoFreteVm, Frete>();
        }
    }
}
