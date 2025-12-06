namespace CalculoFrete.Api.Models
{
    public record ConsultarItemPedidoResumidoVm
    {
        public Guid Id { get; set; }
        public ConsultarProdutoVm Produto { get; set; }
        public ConsultarFreteResumoVm Frete { get; set; }
    }
}
