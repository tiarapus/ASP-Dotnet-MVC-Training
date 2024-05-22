using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace D1_Training.ViewModels.MasterTA;

public class MasterTAViewModel
{
    public long Id {get; set;}

    [Required(ErrorMessage = "Periode harus diisi!")]
    public string Periode { get; set; }

    [Required(ErrorMessage = "Nama periode harus diisi!")]
    public string Namaperiode{ get; set; }
}
