using Microsoft.Extensions.Configuration;
using OnionSolution.Persistence.Properties;

namespace OnionSolution.Persistence.Configs
{
    static class PredefinedConfigs
    {
        public static string PostgreSqlConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OnionSolution.API"));
                configurationManager.AddJsonFile("appsettings.json", false, true);

                return configurationManager.GetConnectionString(Resources.PostgresqlLocal) ?? throw new ArgumentNullException("Connection string not found!");
            }
        }
    }
}
