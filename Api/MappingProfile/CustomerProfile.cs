using Api.Viewmodel;
using AutoMapper;
using Domain.Models;
using Domain.Utility;

namespace Api.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerViewModel, Customer>()
                .ForMember(x => x.CustomerKey, x => x.MapFrom(x => Utilities.GetSequenceNumber()));
        }
    }
}
