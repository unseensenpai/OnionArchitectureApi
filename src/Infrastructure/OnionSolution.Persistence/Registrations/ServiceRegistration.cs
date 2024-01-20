using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionSolution.Application.Abstractions;
using OnionSolution.Persistence.Concretes;
using OnionSolution.Persistence.Contexts;
using OnionSolution.Persistence.Properties;
using System.Reflection;

namespace OnionSolution.Persistence.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IProductService, ProductService>();

            services.AddDbContext<OnionSolutionEFDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(Resources.PostgresqlLocal));
            });
        }
    }
}
