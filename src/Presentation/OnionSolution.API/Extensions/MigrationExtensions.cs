using Microsoft.EntityFrameworkCore;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            using OnionSolutionEFDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<OnionSolutionEFDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
