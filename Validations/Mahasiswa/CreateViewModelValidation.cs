using FluentValidation;
using D1_Training.ViewModels.Mahasiswa;
using System.Linq.Expressions;
using D1_Training.Validations.CustomValidations;

namespace TrainingCore.Validations.Mahasiswa;

public class CreateViewModelValidation : AbstractValidator<CreateMahasiswaViewModel>
{
    public CreateViewModelValidation(MahasiswaCustomValidation mahasiswa)
    {
        RuleFor(field => field.Nim)
            .NotEmpty().WithMessage("Harus Diisi")
            .Length(8).WithMessage("Wajib 8 karakter")
            .Matches("^[0-9]*$").WithMessage("Harus angka")
            .Must(mahasiswa.MustBeUnique).WithMessage("Nim sudah digunakan.");

        RuleFor(field => field.Nama).NotEmpty();
        RuleFor(field => field.Fakultas).NotEmpty();
        RuleFor(field => field.Prodi).NotEmpty();
    }
}