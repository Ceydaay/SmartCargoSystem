using Microsoft.Extensions.DependencyInjection;
using SmartCargo.Application.Interfaces;
using SmartCargo.Persistence.Repositories;
using SmartCargo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SmartCargo.Infrastructure.DependencyInjection
{
    // Uygulamanın altyapı servislerini (DB, repo vs.) uygulamaya ekleyen sınıf
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // DbContext, PostgreSQL ile konfigüre ediliyor
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Shipment repository servis olarak ekleniyor
            services.AddScoped<IShipmentRepository, ShipmentRepository>();

            return services;
        }
    }
}
