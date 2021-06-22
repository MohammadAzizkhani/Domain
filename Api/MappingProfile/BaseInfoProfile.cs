using Api.Viewmodel.BaseInfo;
using Api.Viewmodel.Country;
using AutoMapper;
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
        }
    }
}
