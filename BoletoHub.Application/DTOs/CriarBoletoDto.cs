namespace BoletoHub.Application.DTOs;

public record CriarBoletoDto(
    Guid UserId,
    decimal Valor,
    DateTime DataVencimento
);
