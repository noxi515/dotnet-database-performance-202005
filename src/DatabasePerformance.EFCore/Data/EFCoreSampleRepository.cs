using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabasePerformance.Data
{
    public class EFCoreSampleRepository : IEFCoreSampleRepository
    {
        private readonly DatabaseContext _context;

        public EFCoreSampleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async ValueTask AddAsync(IEnumerable<SampleEntity> data)
        {
            await _context.AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}