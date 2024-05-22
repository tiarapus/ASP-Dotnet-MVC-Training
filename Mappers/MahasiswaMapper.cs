using AutoMapper;
using D1_Training.Models;
namespace D1_Training.Mappers;

// map thru the ViewModels and models to match same object
public class MahasiswaMapper : Profile
{
    public MahasiswaMapper(){

    CreateMap<ViewModels.Mahasiswa.MahasiswaViewModel, Mahasiswa>()
    .ForMember(
        dest => dest.UpdatedAt,
        opt => opt.MapFrom(src => DateTime.Now)
     )
    .ForMember(
        dest => dest.CreatedAt,
        opt => opt.MapFrom(src => DateTime.Now)
     )

    .ForMember(
        dest => dest.DeletedAt,
        opt => opt.MapFrom(src => DateTime.Now)
     );

    // Create<sourceModel, destinationModel>(); => createMap format
    CreateMap<Mahasiswa, ViewModels.Mahasiswa.MahasiswaViewModel>().ReverseMap();
    CreateMap<Mahasiswa, ViewModels.Mahasiswa.UpdateMahasiswaViewModel>();
    CreateMap<Mahasiswa, ViewModels.Mahasiswa.DeleteMahasiswaViewModel>();
    
    
    }
    
}