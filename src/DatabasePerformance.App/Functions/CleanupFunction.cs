using System.Threading.Tasks;
using Dapper;
using DatabasePerformance.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace DatabasePerformance.Functions
{
    public class CleanupFunction
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CleanupFunction(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        [FunctionName("GetCleanup")]
        public async Task<ActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "cleanup")] HttpRequest request)
        {
            await using var conn = _sqlConnectionFactory.Create();
            await conn.ExecuteAsync("DELETE FROM sample;");

            return new OkResult();
        }
    }
}