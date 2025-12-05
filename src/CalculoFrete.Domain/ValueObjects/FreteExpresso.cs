using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

public record FreteExpresso : Frete
{
    protected override decimal TaxaFixa => 10;

    public FreteExpresso(decimal pesoEmKg, decimal distanciaEmKm) : base(ModalidadeFrete.Expresso, pesoEmKg, distanciaEmKm) { }

    protected override void CalcularPrazoEntrega()
    {
        PrazoEntrega = new PrazoEntrega(1, 3);
    }

    protected override void CalcularValor(decimal pesoEmKg, decimal distanciaemKm)
    {
        Valor = (pesoEmKg * 2M) + (distanciaemKm * 0.8M) + TaxaFixa;
    }
}
