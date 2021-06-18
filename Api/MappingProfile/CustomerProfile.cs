using Api.Viewmodel;
using AutoMapper;
using Domain.Enums;
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


            CreateMap<PageCollection<Customer>, PageCollection<CustomerDto>>()
                .ForMember(x => x.TotalRecord, x => x.MapFrom(x => x.TotalRecord))
                .ForMember(x => x.Pages, x => x.MapFrom(x => x.Pages))
                .ForMember(x => x.Data, x => x.MapFrom(x => x.Data));

            CreateMap<Customer,CustomerDto>()
                .ForMember(x => x.Email, x => x.MapFrom(x => x.Email))
                .ForMember(x => x.ShopNameFa, x => x.MapFrom(x => x.ShopNameFa))
                .ForMember(x => x.Guild, x => x.MapFrom(x => x.Guild.CategoryName))
                .ForMember(x => x.Guild, x => x.MapFrom(x => $"{x.Guild.CategoryName} - {x.Guild.CategoryCode}"));

            CreateMap<Merchant, MerchantViewModel>()
                .ForMember(x => x.StatusTitle, x => x.MapFrom(x => x.Status == (int)MerchantStateEnum.Enable ? MerchantStateEnum.Enable.GetEnumDescription() : MerchantStateEnum.Disable.GetEnumDescription()));


            CreateMap<CustomersIban, AddIbanViewModel>().ReverseMap();

            CreateMap<CustomersIban, IbanDto>();
        }
    }
}
