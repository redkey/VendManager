using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendManager.Application.Persistence;
using VendManager.Persistence.Repositories;

namespace VendManager.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VendorManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("VendManagerDatabaseConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMachineRepository, MachineGroupRepository>();
            services.AddScoped<IMachinesRepository, MachinesRepository>();
            services.AddScoped<ISensorBarRepository, SensorBarRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<ISensorValueHistoryRepository, SensorValueHistoryRepository>();

            return services;
        }
    }
}
