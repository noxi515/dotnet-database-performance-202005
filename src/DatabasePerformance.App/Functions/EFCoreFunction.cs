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
    public class EFCoreFunction
    {
        private readonly IEFCoreSampleRepository _repository;

        public EFCoreFunction(IEFCoreSampleRepository repository)
        {
            _repository = repository;
        }

        [FunctionName("GetEFCore")]
        public async Task<ActionResult> GetAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "efcore")] HttpRequest request,
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