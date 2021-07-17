using System;
using System.IO;
using System.Runtime.InteropServices;
using Api.Viewmodel;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Utility;
using Microsoft.AspNetCore.Http;

namespace Api.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerViewModel, Customer>()
                .ForMember(x => x.CustomerKey, x => x.MapFrom(x => Utilities.GetSequenceNumber()))
                .ForMember(x => x.ShopAddress, c => c.MapFrom(x => x.ShopAddress));


            CreateMap<PageCollection<Customer>, PageCollection<CustomerDto>>()
                .ForMember(x => x.TotalRecord, x => x.MapFrom(x => x.TotalRecord))
                .ForMember(x => x.Pages, x => x.MapFrom(x => x.Pages))
                .ForMember(x => x.Data, x => x.MapFrom(x => x.Data));

            CreateMap<Customer, CustomerDto>()
                .ForMember(x => x.Email, x => x.MapFrom(x => x.Email))
                .ForMember(x => x.ShopNameFa, x => x.MapFrom(x => x.ShopNameFa))
                .ForMember(x => x.Guild, x => x.MapFrom(x => x.Guild.CategoryName))
                .ForMember(x => x.Guild, x => x.MapFrom(x => $"{x.Guild.CategoryName} - {x.Guild.CategoryCode}"));

            CreateMap<Merchant, MerchantViewModel>()
                .ForMember(x => x.StatusTitle, x => x.MapFrom(x => x.Status == (int)MerchantStateEnum.Enable ? MerchantStateEnum.Enable.GetEnumDescription() : MerchantStateEnum.Disable.GetEnumDescription()));


            CreateMap<CustomersIban, AddIbanViewModel>().ReverseMap();

            CreateMap<CustomersIban, IbanDto>();

            CreateMap<UploadFileViewModel, Document>()
                .ForMember(x => x.InsertTime, x => x.MapFrom(x => DateTime.Now))
                .ForMember(x => x.CustomerId, x => x.MapFrom(x => x.CustomerId))
                .ForMember(x => x.DocTypeId, x => x.MapFrom(x => x.DocTypeId))
                .ForMember(x => x.ContentType, x => x.MapFrom(x => x.FormFile.ContentType))
                .ForMember(x => x.Data, v => v.MapFrom(x => GetBytes(x.FormFile)
                ));


        }
        private byte[] GetBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            return fileBytes;
        }
    }
}
