using Microsoft.Data.SqlClient;

namespace DatabasePerformance.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Create() => new SqlConnection(_connectionString);
    }
}