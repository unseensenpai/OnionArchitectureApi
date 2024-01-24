using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionSolution.Application.Abstractions;
using OnionSolution.Application.Repositories.CustomerRepository;
using OnionSolution.Application.Repositories.OrderRepository;
using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Persistence.Concretes;
using OnionSolution.Persistence.Contexts;
using OnionSolution.Persistence.Properties;
using OnionSolution.Persistence.Repositories.CustomerRepository;
using OnionSolution.Persistence.Repositories.OrderRepository;
using OnionSolution.Persistence.Repositories.ProductRepository;

namespace OnionSolution.Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IProductService, ProductService>();

            services.AddDbContext<OnionSolutionEFDbContext>(options =>
            {
                //options.UseNpgsql(configuration.GetConnectionString(Resources.PostgresqlLocal));
                options.UseNpgsql(configuration.GetConnectionString(Resources.PostgresqlOrchestration), 
                    c => c.MigrationsHistoryTable(Resources.EFMigrationHistoryName, Resources.EFMigrationHistorySchemeName));
            });

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString(Resources.RegisCacheSectionName);
            });

            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICachedProductRepository, CachedProductRepository>();
        }
    }
}
