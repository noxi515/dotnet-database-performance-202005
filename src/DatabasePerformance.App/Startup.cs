using DatabasePerformance.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(DatabasePerformance.Startup))]

namespace DatabasePerformance
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            services.AddSqlConnectionFactory();
            services.AddBulkCopy();
            services.AddDapper();
            services.AddEFCore();
        }
    }
}