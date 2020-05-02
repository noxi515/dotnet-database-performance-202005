using DatabasePerformance.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DatabasePerformance.DependencyInjection
{
    public static class DapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection service)
        {
            service.AddScoped<IDapperSampleRepository, DapperSampleRepository>();
            return service;
        }
    }
}