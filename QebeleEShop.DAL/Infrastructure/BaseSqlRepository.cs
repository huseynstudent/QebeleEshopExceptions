using Microsoft.Data.SqlClient;

namespace QebeleEShop.DAL.Infrastructure;

public class BaseSqlRepository
{
    private readonly string _connectionString;

    public BaseSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
