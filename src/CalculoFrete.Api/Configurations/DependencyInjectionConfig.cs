using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Services;

namespace CalculoFrete.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Pedido>, InMemoryRepository<Pedido>>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IFreteService, FreteService>();
        }
    }
}
