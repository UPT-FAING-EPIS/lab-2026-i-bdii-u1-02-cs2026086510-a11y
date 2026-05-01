using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar soporte para Controladores
builder.Services.AddControllers();

// 2. Configurar la base de datos (Ya lo tenías bien)
builder.Services.AddDbContext<BdClientesContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

// 3. Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Habilitar Swagger fuera del bloque IsDevelopment para que funcione en Docker
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 5. Mapear las rutas de los controladores
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
