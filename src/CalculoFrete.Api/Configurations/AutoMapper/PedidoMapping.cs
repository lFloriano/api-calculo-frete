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
            CreateMap<ItemPedido, ConsultarItemPedidoVm>();
            CreateMap<Produto, ConsultarProdutoVm>();

            // Viewmodel -> domain
            CreateMap<AdicionarPedidoVm, Pedido>();
            CreateMap<AdicionarPedidoItemPedidoVm, ItemPedido>();
            CreateMap<AdicionarPedidoFreteVm, Frete>();
        }
    }
}
