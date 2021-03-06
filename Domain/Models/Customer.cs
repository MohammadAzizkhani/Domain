using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
            CustomersIbans = new HashSet<CustomersIban>();
            MarketerContractCustomers = new HashSet<MarketerContract>();
            MarketerContractMarketers = new HashSet<MarketerContract>();
            Merchants = new HashSet<Merchant>();
            Requests = new HashSet<Request>();
        }

        public long Id { get; set; }
        public long? PersonId { get; set; }
        public string MobileNumber { get; set; }
        public string Telephone { get; set; }
        public string AddressFa { get; set; }
        public string AddressEn { get; set; }
        public string Email { get; set; }
        public string WebSiteAddress { get; set; }
        public bool? IsSharedAccount { get; set; }
        public bool? IsMultiAccount { get; set; }
        public string ShopPostalCode { get; set; }
        public string ShopFaxNumber { get; set; }
        public string ShopTelephoneNumber { get; set; }
        public string ShopCityPreCode { get; set; }
        public string ShopBusinessLicenseNumber { get; set; }
        public string ShopBusinessLicenseIssueDate { get; set; }
        public string ShopBusinessLicenseExpireDate { get; set; }
        public string ShopEmail { get; set; }
        public string ShopAddress { get; set; }
        public string BusinesslicenseImg { get; set; }
        public string RedirectUrl { get; set; }
        public int GuildId { get; set; }
        public string ShopLogo { get; set; }
        public string CustomerKey { get; set; }
        public string CustomerValue { get; set; }
        public string ShopNameFa { get; set; }
        public string ShopNameEn { get; set; }
        public string ProvinceAbbreviation { get; set; }
        public string CountryAbbreviation { get; set; }
        public int? CityCode { get; set; }
        public string TaxPayerCode { get; set; }

        public virtual GuildCategory Guild { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<CustomersIban> CustomersIbans { get; set; }
        public virtual ICollection<MarketerContract> MarketerContractCustomers { get; set; }
        public virtual ICollection<MarketerContract> MarketerContractMarketers { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
