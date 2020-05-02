using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabasePerformance.Data
{
    public interface ISampleRepository
    {
        ValueTask AddAsync(IEnumerable<SampleEntity> data);
    }
}