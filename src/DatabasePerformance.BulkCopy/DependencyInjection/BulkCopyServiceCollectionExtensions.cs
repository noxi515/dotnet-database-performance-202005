using DatabasePerformance.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DatabasePerformance.DependencyInjection
{
    public static class BulkCopyServiceCollectionExtensions
    {
        public static IServiceCollection AddBulkCopy(this IServiceCollection services)
        {
            services.AddScoped<IBulkCopySampleRepository, BulkCopySampleRepository>();
            return services;
        }
    }
}