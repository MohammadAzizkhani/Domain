using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Viewmodel;
using AutoMapper;
using Domain.Models;
using Domain.Utility;

namespace Api.MappingProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();

            CreateMap<AddPersonViewModel, Person>()
                .ForMember(p => p.InsertDateTime,
                    x => x.MapFrom(x => DateTime.Now))
                .ForMember(p => p.Customers,
                    x => x.MapFrom(x => new List<Customer>
                    {
                        new (){
                        MobileNumber = x.Customer.MobileNumber,
                        Telephone = x.Customer.Telephone,
                        AddressFa = x.Customer.AddressFa,
                        AddressEn = x.Customer.AddressEn,
                        Email = x.Customer.Email,
                        WebSiteAddress = x.Customer.WebSiteAddress,
                        IsSharedAccount = x.Customer.IsSharedAccount,
                        IsMultiAccount = x.Customer.IsMultiAccount,
                        ShopPostalCode = x.Customer.ShopPostalCode,
                        ShopFaxNumber = x.Customer.ShopFaxNumber,
                        ShopTelephoneNumber = x.Customer.ShopTelephoneNumber,
                        ShopCityPreCode = x.Customer.ShopCityPreCode,
                        ShopBusinessLicenseNumber = x.Customer.ShopBusinessLicenseNumber,
                        ShopBusinessLicenseIssueDate = x.Customer.ShopBusinessLicenseIssueDate,
                        ShopEmail = x.Customer.ShopEmail,
                        RedirectUrl = x.Customer.RedirectUrl,
                        GuildId = x.Customer.GuildId,
                        ShopLogo = x.Customer.ShopLogo,
                        CustomerKey = Utilities.GetSequenceNumber(),
                        ShopNameFa = x.Customer.ShopNameFa,
                        ShopNameEn = x.Customer.ShopNameEn,
                        ProvinceAbbreviation = x.Customer.ProvinceAbbreviation,
                        CountryAbbreviation = x.Customer.CountryAbbreviation,
                        CityCode = x.Customer.CityCode,
                        TaxPayerCode = x.Customer.TaxPayerCode,
                        CustomersIbans = x.Customer.Ibans.Select(p=>new CustomersIban
                        {
                            AccountNumber = p.AccountNumber,
                            ShareAmountMax = p.ShareAmountMax,
                            IsMain = p.IsMain,
                            ShareAmountMin = p.ShareAmountMin,
                            SharedAmount = p.SharedAmount,
                            Iban = p.Iban,
                            ShareType = p.ShareType
                        }).ToList(),
                        Contracts = new List<Contract>
                        {
                            new()
                            {
                                ShareAmountMin = x.Customer.Contract.ShareAmountMin,
                                ShareType = x.Customer.Contract.ShareType,
                                SharedAmount = x.Customer.Contract.SharedAmount,
                                ContractNumber = x.Customer.Contract.ContractNumber,
                                Description = x.Customer.Contract.Description,
                                Introduced = x.Customer.Contract.Introduced,
                                ExpireDate = x.Customer.Contract.ExpireDate,
                                IntroducedSharedAmount = x.Customer.Contract.IntroducedSharedAmount,
                                IntroducedSharedType = x.Customer.Contract.IntroducedSharedType,
                                ProjectId = x.Customer.Contract.ProjectId,
                                ShareAmountMax = x.Customer.Contract.ShareAmountMax,
                                ServiceStartDate = x.Customer.Contract.ServiceStartDate
                            }
                        }
                        }
                    }));
        }
    }
}
