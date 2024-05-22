// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;

namespace D1_Training.Models;

public class Mahasiswa
{
    public long Id {get; set;}

    public string Nim { get; set; }
    public string Nama { get; set; }
    public string Prodi { get; set; }
    public string Fakultas { get; set; }
    public string Alamat { get; set; }

    public string? Agama { get; set; }

    public string? Gender { get; set; }

    public DateTime? CreatedAt {get;set;}
    public DateTime? UpdatedAt {get;set;}
    public DateTime? DeletedAt {get;set;}
    


}
