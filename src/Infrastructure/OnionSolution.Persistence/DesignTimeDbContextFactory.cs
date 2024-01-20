using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnionSolution.Persistence.Configs;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnionSolutionEFDbContext>
    {
        public OnionSolutionEFDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnionSolutionEFDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(PredefinedConfigs.PostgreSqlConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
