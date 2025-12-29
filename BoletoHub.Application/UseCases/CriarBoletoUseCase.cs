using BoletoHub.Application.DTOs;
using BoletoHub.Application.Interfaces;
using BoletoHub.Domain.Entities;

namespace BoletoHub.Application.UseCases;

public class CriarBoletoUseCase
{
    private readonly IBoletoRepository _repository;

    public CriarBoletoUseCase(IBoletoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CriarBoletoDto dto)
    {
        var codigoBarras = Guid.NewGuid().ToString().Replace("-", "");

        var boleto = new Boleto(
            dto.UserId,
            codigoBarras,
            dto.Valor,
            dto.DataVencimento
        );

        await _repository.AddAsync(boleto);

        return boleto.Id;
    }
}
