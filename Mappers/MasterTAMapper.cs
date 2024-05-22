using AutoMapper;
using D1_Training.Models;
namespace D1_Training.Mappers;

public class MasterTAMapper : Profile
{
    public MasterTAMapper() {
        CreateMap<ViewModels.MasterTA.MasterTAViewModel, MasterTA>().ReverseMap();
    }
}