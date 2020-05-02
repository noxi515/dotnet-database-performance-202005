using Microsoft.Data.SqlClient;

namespace DatabasePerformance.Data
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Create();
    }
}