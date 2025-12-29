using BoletoHub.Application.Interfaces;
using BoletoHub.Domain.Entities;
using BoletoHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BoletoHub.Infrastructure.Repositories;

public class BoletoRepository : IBoletoRepository
{
    private readonly AppDbContext _context;

    public BoletoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Boleto boleto)
    {
        _context.Boletos.Add(boleto);
        await _context.SaveChangesAsync();
    }

    public async Task<Boleto?> GetByIdAsync(Guid id)
    {
        return await _context.Boletos.FindAsync(id);
    }

    public async Task<IEnumerable<Boleto>> GetByUserAsync(Guid userId)
    {
        return await _context.Boletos
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Boleto boleto)
    {
        _context.Boletos.Update(boleto);
        await _context.SaveChangesAsync();
    }
}
