using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Transactions;
using DatabasePerformance.Data;
using Microsoft.Extensions.Logging;

namespace DatabasePerformance
{
    public static class MeasureRepositoryPerformance
    {
        public static async Task InsertAsync(ILogger logger, ISampleRepository repository, int count)
        {
            logger.LogInformation("Before measure");

            var data = SampleEntity.CreateList(count);

            using var tx = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var sw = new Stopwatch();
            sw.Start();

            await repository.AddAsync(data);

            sw.Stop();

            tx.Complete();

            logger.LogMetric("InsertPerformance", sw.ElapsedMilliseconds, new Dictionary<string, object>
            {
                {"Repository", repository.GetType().Name},
                {"Count", count}
            });
            logger.LogInformation("After measure");
        }
    }
}