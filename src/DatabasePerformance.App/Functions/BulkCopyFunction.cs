using System.Linq;
using System.Threading.Tasks;
using DatabasePerformance.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DatabasePerformance.Functions
{
    public class BulkCopyFunction
    {
        private readonly IBulkCopySampleRepository _repository;

        public BulkCopyFunction(IBulkCopySampleRepository repository)
        {
            _repository = repository;
        }

        [FunctionName("GetBulkCopy")]
        public async Task<ActionResult> GetAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "bulk-copy")] HttpRequest request,
            ILogger logger
        )
        {
            if (!int.TryParse(request.Query["count"].FirstOrDefault(), out var count))
            {
                count = 1000;
            }

            await MeasureRepositoryPerformance.InsertAsync(logger, _repository, count);
            return new OkResult();
        }
    }
}