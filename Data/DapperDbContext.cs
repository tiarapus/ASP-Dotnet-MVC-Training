using Microsoft.Data.SqlClient;
using System.Data;
// 


namespace D1_Training.Data;

public class DapperDbContext{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperDbContext(IConfiguration configuration){
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}




