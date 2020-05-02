using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabasePerformance.Data
{
    public class EFCoreSampleRepository : IEFCoreSampleRepository
    {
        public async ValueTask AddAsync(IEnumerable<SampleEntity> data)
        {
            
        }
    }
}