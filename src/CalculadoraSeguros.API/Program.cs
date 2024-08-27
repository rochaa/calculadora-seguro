using CalculadoraSeguros.Domain.Repositories;
using CalculadoraSeguros.Infra.Data;
using CalculadoraSeguros.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = AppDomain.CurrentDomain.Load("CalculadoraSeguros.Domain");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddDbContext<CalculadoraSeguroContext>(opt => opt.UseInMemoryDatabase("CalculoSeguroMemoria"));
builder.Services.AddScoped<ICalculoSeguroRepository, CalculoSeguroRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
