using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace DatabasePerformance.Data
{
    public class DapperSampleRepository : IDapperSampleRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public DapperSampleRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async ValueTask AddAsync(IEnumerable<SampleEntity> data)
        {
            await using var conn = _sqlConnectionFactory.Create();
            await conn.ExecuteAsync(@"
INSERT INTO sample
(id, name, age, date)
VALUES
(@Id, @Name, @Age, @Date);", data);
        }
    }
}