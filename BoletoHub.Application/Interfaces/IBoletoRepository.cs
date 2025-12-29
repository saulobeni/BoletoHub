using BoletoHub.Domain.Entities;

namespace BoletoHub.Application.Interfaces;

public interface IBoletoRepository
{
    Task AddAsync(Boleto boleto);
    Task<Boleto?> GetByIdAsync(Guid id);
    Task<IEnumerable<Boleto>> GetByUserAsync(Guid userId);
    Task UpdateAsync(Boleto boleto);
}
