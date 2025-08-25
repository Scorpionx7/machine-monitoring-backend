using MachineMonitoring.Data;
using MachineMonitoring.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Adicionar o DbContext com banco de dados em memória
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar a camada de serviço
builder.Services.AddScoped<IMachineService, MachineService>();

// 3. Adicionar serviços para os controllers e Swagger (que já estavam lá)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Linha necessária para que os controllers funcionem
app.MapControllers();

app.Run();