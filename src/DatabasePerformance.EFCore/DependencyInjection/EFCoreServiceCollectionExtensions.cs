using DatabasePerformance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabasePerformance.DependencyInjection
{
    public static class EFCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddEFCore(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>((provider, builder) =>
            {
                var sqlConnectionFactory = provider.GetRequiredService<ISqlConnectionFactory>();
                builder.UseSqlServer(sqlConnectionFactory.Create(), options =>
                {
                });
            });
            services.AddScoped<IEFCoreSampleRepository, EFCoreSampleRepository>();
            return services;
        }
    }
}