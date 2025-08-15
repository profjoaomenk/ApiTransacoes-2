using Microsoft.EntityFrameworkCore;
using MyApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    )
);

// Adicionar controllers
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI (opcional, mas recomendado)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
