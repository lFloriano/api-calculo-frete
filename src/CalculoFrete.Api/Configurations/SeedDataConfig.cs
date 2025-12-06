using CalculoFrete.Core.Data;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Enums;
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
                var produto = CriarProduto(i);
                var pedido = new Pedido(clienteId);
                pedido.AtualizarItens(CriarItensPedido(pedido.Id));

                repo.Adicionar(pedido).GetAwaiter().GetResult();
            }
        }

        private static IEnumerable<ItemPedido> CriarItensPedido(Guid produtoId)
        {
            var item1 = new ItemPedido(produtoId, ModalidadeFrete.Normal);
            item1.CalcularFrete(1, 3);

            var item2 = new ItemPedido(produtoId, ModalidadeFrete.Expresso);
            item2.CalcularFrete(10, 20);

            var item3 = new ItemPedido(produtoId, ModalidadeFrete.Agendado, DateOnly.FromDateTime(DateTime.Now.AddDays(10)));
            item3.CalcularFrete(3, 8, item3.DataAgendamento);


            return new List<ItemPedido>()
            {
                item1,
                item2,
                item3
            };
        }

        private static Produto CriarProduto(int indice)
        {
            return new Produto(
                $"Produto {indice}",
                (indice * 4M),
                new Cep($"0000{indice}00")
            );
        }
    }
}