using D1_Training.Data;
using D1_Training.Interfaces;
using D1_Training.Models;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
// 



namespace D1_Training.Repositories;


// T = Type parameter, semua yang pake harus pake fungsi
// implement
public class MahasiswaRepository : IMahasiswaRepository
{
    private readonly DapperDbContext _context;

    public MahasiswaRepository(DapperDbContext context){
        _context = context;
    }
    
    public Task<int> Delete(Mahasiswa obj)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Mahasiswa>?> Get()
    {
        var query = "SELECT * FROM Mahasiswa WHERE DeletedAt IS NULL";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<Mahasiswa>(query);
        return result;
    }

    public async Task<Mahasiswa?> GetById(long Id)
    {
        var query = $"SELECT * FROM Mahasiswa WHERE Id = {Id}";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryFirstOrDefaultAsync<Mahasiswa>(query);
        return result;
    }
    public Mahasiswa? GetByNim(string Nim)
    {
        var query = $"SELECT * FROM Mahasiswa WHERE Nim = {Nim}";
        using var connection = _context.CreateConnection();
        var result =  connection.QueryFirstOrDefault<Mahasiswa>(query);
        return result;
    }

    public async Task<int> Insert(Mahasiswa mhs)
    {
        string query = "INSERT INTO Mahasiswa" +
                "(Nim, Nama, Prodi, Fakultas, Alamat, Agama, Gender, CreatedAt) VALUES" +
                "(@Nim, @Nama, @Prodi, @Fakultas, @Alamat, @Agama, @Gender, @CreatedAt)";



        var parameters = new DynamicParameters();
        parameters.Add("Nim", mhs.Nim, DbType.String);
        parameters.Add("Nama", mhs.Nama, DbType.String);
        parameters.Add("Fakultas", mhs.Fakultas, DbType.String);
        parameters.Add("Prodi", mhs.Prodi, DbType.String);
        parameters.Add("Alamat", mhs.Alamat, DbType.String);
        parameters.Add("Agama", mhs.Agama, DbType.String);
        parameters.Add("Gender", mhs.Gender, DbType.String);
        parameters.Add("CreatedAt", DateTime.Now, DbType.DateTime);



        // parameters.Add("UpdatedAt", mhs.UpdatedAt, DbType.DateTime);

        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(query, parameters);
    }

    public async Task<int> SoftDelete(Mahasiswa mhs)
    {

       string Query = $"UPDATE Mahasiswa SET DeletedAt = @DeletedAt WHERE Id = {mhs.Id}";

        var parameters = new DynamicParameters();
        parameters.Add("DeletedAt", DateTime.Now, DbType.DateTime);

        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(Query, parameters);
    }

    public async Task<int> Update(Mahasiswa mhs)
    {
        string Query = $"UPDATE Mahasiswa SET " +
                   $"Nim = @Nim, " +
                   $"Nama = @Nama, " +
                   $"Prodi = @Prodi, " +
                   $"Fakultas = @Fakultas, " +
                   $"Alamat = @Alamat, " +
                   $"Agama = @Agama, " +
                   $"Gender = @Gender, " +
                   $"UpdatedAt = @UpdatedAt " +
                   $"WHERE Id = {mhs.Id}";

        var parameters = new DynamicParameters();
        parameters.Add("Nim", mhs.Nim, DbType.String);
        parameters.Add("Nama", mhs.Nama, DbType.String);
        parameters.Add("Fakultas", mhs.Fakultas, DbType.String);
        parameters.Add("Prodi", mhs.Prodi, DbType.String);
        parameters.Add("Alamat", mhs.Alamat, DbType.String);
        parameters.Add("Agama", mhs.Agama, DbType.String);
        parameters.Add("Gender", mhs.Gender, DbType.String);
        parameters.Add("UpdatedAt", DateTime.Now, DbType.DateTime);

        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(Query, parameters);
    }


}
