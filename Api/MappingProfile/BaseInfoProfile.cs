using Api.Viewmodel.BaseInfo;
using Api.Viewmodel.Country;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Utility;

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

            CreateMap<Project, ProjectDto>().ForMember(x => x.ShareTypeTitle, c => c.MapFrom(x => x.ShareType == "1" ? ShareTypeEnum.Percentage.GetEnumDescription() : x.ShareType == "static" ? ShareTypeEnum.Amount.GetEnumDescription() : ""))

                .ForMember(x => x.ShareTypeEnum, x => x.MapFrom(c => c.ShareType == "1" ? ShareTypeEnum.Percentage : ShareTypeEnum.Amount));
            ;
        }
    }
}
