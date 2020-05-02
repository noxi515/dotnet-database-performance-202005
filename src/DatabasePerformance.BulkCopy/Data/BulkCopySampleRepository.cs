using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DatabasePerformance.Data
{
    public class BulkCopySampleRepository : IBulkCopySampleRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public BulkCopySampleRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async ValueTask AddAsync(IEnumerable<SampleEntity> data)
        {
            await using var conn = _sqlConnectionFactory.Create();
            await conn.OpenAsync();

            using var dataTable = CreateDataTable(data);
            var sqlBulkCopy = new SqlBulkCopy(conn)
            {
                DestinationTableName = "sample"
            };
            await sqlBulkCopy.WriteToServerAsync(dataTable);
        }

        private DataTable CreateDataTable(IEnumerable<SampleEntity> data)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(Guid));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("age", typeof(int));
            dataTable.Columns.Add("date", typeof(DateTime));

            foreach (var entity in data)
            {
                var row = dataTable.NewRow();
                row["id"] = entity.Id;
                row["name"] = entity.Name;
                row["age"] = entity.Age;
                row["date"] = entity.Date;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}