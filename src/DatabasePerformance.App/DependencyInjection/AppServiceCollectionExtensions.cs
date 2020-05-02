using DatabasePerformance.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabasePerformance.DependencyInjection
{
    public static class AppServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlConnectionFactory(this IServiceCollection services)
        {
            services.AddTransient<ISqlConnectionFactory>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return new SqlConnectionFactory(configuration.GetConnectionStringOrSetting("Sample"));
            });
            return services;
        }
    }
}