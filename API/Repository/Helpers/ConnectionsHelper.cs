using System.Data.Common;
using Npgsql;

namespace school_admin_api.Repository.Helpers;

public class ConnectionsHelper
{
    private readonly IConfiguration _configuration;

    public ConnectionsHelper(
        IConfiguration configuration
        )
    {
        _configuration = configuration;
    }

    public DbConnection CreateConnection() => new NpgsqlConnection(_configuration.GetConnectionString("school_db"));
}
