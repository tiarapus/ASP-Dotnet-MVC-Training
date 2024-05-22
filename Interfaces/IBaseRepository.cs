using Microsoft.Data.SqlClient;
using System.Data;
// 


namespace D1_Training.Interfaces;

// T = Type parameter, semua yang pake harus pake fungsi
public interface IBaseRepository<T>
{
    Task<IEnumerable<T>?> Get();
    Task<T?> GetById(long id);
    Task<int> Insert(T obj);
    Task<int> Update(T obj);
    Task<int> SoftDelete(T obj);
    Task<int> Delete(T obj);

}




