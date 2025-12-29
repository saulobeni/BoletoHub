using BoletoHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoHub.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Boleto> Boletos => Set<Boleto>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(u =>
        {
            u.ToTable("users");
            u.HasKey(x => x.Id);
            u.Property(x => x.Name).IsRequired().HasMaxLength(150);
            u.Property(x => x.Email).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<Boleto>(b =>
        {
            b.ToTable("boletos");
            b.HasKey(x => x.Id);
            b.Property(x => x.Valor).HasPrecision(15, 2);
            b.Property(x => x.CodigoBarras).IsRequired().HasMaxLength(100);
        });
    }
}
