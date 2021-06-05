using Api.Viewmodel;
using AutoMapper;
using Domain.Models;

namespace Api.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerViewModel, Customer>();
        }
    }
}
