using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Boutique.Infrastructure.Data;
using Boutique.Infrastructure.Repositories;
using Boutique.Domain.Interfaces;

namespace Boutique.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar DbContext con SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registrar repositorios concretos que implementen interfaces del Domain
            services.AddScoped<IProductoRepository, ProductoRepository>();

            return services;
        }
    }
}
