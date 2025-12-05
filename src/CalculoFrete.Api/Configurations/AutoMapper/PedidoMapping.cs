using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain;

namespace CalculoFrete.Api.Configurations.AutoMapper
{
    public class PedidoMappings : Profile
    {
        public PedidoMappings()
        {
            // Domain -> view model
            CreateMap<Pedido, ConsultarPedidoVm>();
        }
    }
}
