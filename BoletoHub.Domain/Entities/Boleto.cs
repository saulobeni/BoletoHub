using BoletoHub.Domain.Enums;

namespace BoletoHub.Domain.Entities;

public class Boleto
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string CodigoBarras { get; private set; } = null!;
    public decimal Valor { get; private set; }
    public BoletoStatus Status { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public DateTime? DataPagamento { get; private set; }

    protected Boleto() { }

    public Boleto(Guid userId, string codigoBarras, decimal valor, DateTime vencimento)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        CodigoBarras = codigoBarras;
        Valor = valor;
        DataVencimento = vencimento;
        Status = BoletoStatus.Pendente;
    }

    public void MarcarComoPago()
    {
        Status = BoletoStatus.Pago;
        DataPagamento = DateTime.UtcNow;
    }
}
