using D1_Training.Models;
using Microsoft.Data.SqlClient;
using System.Data;
// 


namespace D1_Training.Interfaces;

// T = Type parameter, semua yang pake harus pake fungsi
public interface IMahasiswaRepository : IBaseRepository<Mahasiswa>
{
    Mahasiswa? GetByNim(String nim);
}