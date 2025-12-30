using BoletoHub.Application.Interfaces;
using BoletoHub.Application.UseCases;
using BoletoHub.Infrastructure.Persistence;
using BoletoHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controladores
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

// Dependências
builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<CriarBoletoUseCase>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
