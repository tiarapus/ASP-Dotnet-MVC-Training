using Microsoft.AspNetCore.Mvc.Rendering;

namespace D1_Training.ViewModels.Mahasiswa;
  
public class CreateMahasiswaViewModel
{
    public string Nim { get; set; }
    public string Nama { get; set; }
    public string Prodi { get; set; }
    public string Fakultas { get; set; }
    public string Alamat { get; set; }
    public string? Agama { get; set; }
    public string? Gender { get; set; }

    public List<SelectListItem> FakultasSelectOptions { get; init; } = new()
    {
        new SelectListItem { Text = "Psikologi", Value = "Psikologi" },
        new SelectListItem { Text = "Ekonomi", Value = "Ekonomi" },
        new SelectListItem { Text = "Sastra", Value = "Sastra" }
    };
    public List<SelectListItem> ProdiSelectOptions { get; init; } = new()
    {
        new SelectListItem { Text = "Akuntansi", Value = "Akuntansi" },
        new SelectListItem { Text = "Ekonomi", Value = "Ekonomi" },
        new SelectListItem { Text = "Kedokteran", Value = "Kedokteran" },
        new SelectListItem { Text = "Sistem Informasi", Value = "Sistem Informasi" },
        new SelectListItem { Text = "Informatika", Value = "Informatika" }
    };
}


