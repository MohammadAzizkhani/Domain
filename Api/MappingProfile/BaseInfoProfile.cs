using Api.Viewmodel.BaseInfo;
using Api.Viewmodel.Country;
using AutoMapper;
using Domain.Enums;
using Domain.Models;

namespace Api.MappingProfile
{
    public class BaseInfoProfile : Profile
    {
        public BaseInfoProfile()
        {
            CreateMap<AddCountryViewModel, Country>();
            CreateMap<EditCountryViewModel, Country>();
            CreateMap<AddPspViewModel, Psp>();
            CreateMap<EditPspViewModel, Psp>();
            CreateMap<AddProjectViewModel, Project>().ForMember(x => x.ShareType, x => x.MapFrom(c => c.ShareType == ShareTypeEnum.Percentage ? "1" : "static"));

            CreateMap<EditProjectViewModel, Project>().ForMember(x => x.ShareType, x => x.MapFrom(c => c.ShareType == ShareTypeEnum.Percentage ? "1" : "static"));
        }
    }
}
