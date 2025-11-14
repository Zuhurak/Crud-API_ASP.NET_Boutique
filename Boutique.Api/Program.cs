using Boutique.Application.Interfaces;
using Boutique.Application.Services;
using Boutique.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registrar Infrastructure (DbContext + repositorios)
builder.Services.AddInfrastructure(builder.Configuration);

// Registrar servicios de Application
builder.Services.AddScoped<IProductoService, ProductoService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
