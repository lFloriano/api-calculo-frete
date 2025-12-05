using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Configurations
{
    public static class SeedDataConfig
    {
        public static void SeedData(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IRepository<Pedido>>();

            var existePedido = repo.ObterTodosAsync().GetAwaiter().GetResult();
            
            if (existePedido != null && existePedido.Any())
                return;

            for (int i = 1; i <= 5; i++)
            {
                var clienteId = Guid.NewGuid();
                var enderecoEntregaId = Guid.NewGuid();
                var pedido = new Pedido(clienteId, enderecoEntregaId);

                pedido.AtualizarCep(new Cep { Numero = $"0000{i}00" });
                repo.Adicionar(pedido).GetAwaiter().GetResult();
            }
        }
    }
}