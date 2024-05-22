using D1_Training.Data;
using D1_Training.Interfaces;
using D1_Training.Models;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
// 



namespace D1_Training.Repositories;

public class MasterTARepository : IMasterTARepository
{
    private readonly DapperDbContext _context;

    public MasterTARepository(DapperDbContext context){
        _context = context;
    }
    public async Task<int> Delete(MasterTA master)
    {
        string Query = $"DELETE FROM MasterTA WHERE Id = {master.Id}";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(Query);

    }

    public async Task<IEnumerable<MasterTA>?> Get()
    {

        var query = "SELECT * FROM MasterTA";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<MasterTA>(query);
        return result;
    }

    public async Task<MasterTA?> GetById(long id)
    {
        var query = $"SELECT * FROM MasterTA WHERE Id = {id}";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<MasterTA>(query);
        return result;
    }

    public async Task<int> Insert(MasterTA master)
    {

        string Query = "INSERT INTO MasterTA" +
                "(Periode, Namaperiode) VALUES" +
                "(@Periode, @Namaperiode)";



        var parameters = new DynamicParameters();
        parameters.Add("Periode", master.Periode, DbType.String);
        parameters.Add("Namaperiode", master.Namaperiode, DbType.String);

        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(Query, parameters);
    

    }

    public Task<int> SoftDelete(MasterTA obj)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(MasterTA master)
    {
        string Query = $"UPDATE MasterTA SET " +
                   $"Periode = @Periode, " +
                   $"Namaperiode = @Namaperiode " +
                   $"WHERE Id = {master.Id}";

        var parameters = new DynamicParameters();
        parameters.Add("Periode", master.Periode, DbType.String);
        parameters.Add("Namaperiode", master.Namaperiode, DbType.String);

        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(Query, parameters);
    }
}