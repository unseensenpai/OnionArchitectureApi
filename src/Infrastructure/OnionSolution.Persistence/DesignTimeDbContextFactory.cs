using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnionSolution.Persistence.Configs;
using OnionSolution.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
