using D1_Training.Interfaces;
namespace D1_Training.Validations.CustomValidations;

public class MahasiswaCustomValidation
{
    private readonly IMahasiswaRepository _mahasiswa;
    public MahasiswaCustomValidation(IMahasiswaRepository mahasiswa){
        _mahasiswa = mahasiswa;
    }

    public bool MustBeUnique(string? Nim){
        if (Nim is null) return false;
        var mahasiswa = _mahasiswa.GetByNim(Nim);
        return mahasiswa is null;
    }
}