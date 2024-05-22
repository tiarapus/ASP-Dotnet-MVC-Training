using FluentValidation;
using D1_Training.ViewModels.MasterTA;
using System.Linq.Expressions;

namespace TrainingCore.Validations.Mahasiswa;

public class CreateMasterTAViewModelValidation : AbstractValidator<MasterTAViewModel>
{
    public CreateMasterTAViewModelValidation()
    {
        RuleFor(field => field.Periode)
            .NotEmpty().WithMessage("Harus Diisi")
            .Matches("^[0-9]*$").WithMessage("Harus angka");

        RuleFor(field => field.Namaperiode).NotEmpty().WithMessage("Harus Diisi");
    }
}