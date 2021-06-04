using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class InputRegaccPspVw
    {
        public long? CustomerId { get; set; }
        public string InstallationDate { get; set; }
        public string Description { get; set; }
        public string ShaparakDescription { get; set; }
        public byte? RequestTypeId { get; set; }
        public long? PspId { get; set; }
        public byte? RequestStateId { get; set; }
        public string ShaparakTrackingNumber { get; set; }
        public Guid? TrackingNumber { get; set; }
        public byte? ShaparakState { get; set; }
        public DateTime? LastCallTime { get; set; }
        public DateTime? Expr3 { get; set; }
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
        public int CategoryCode { get; set; }
        public long Id { get; set; }
        public bool? IsDisable { get; set; }
        public string NationalNumber { get; set; }
        public string FirstNameFa { get; set; }
        public string LastNameFa { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public int? NationalityId { get; set; }
        public string BirthLocation { get; set; }
        public string BirthDate { get; set; }
        public string BirthCertificatePlaceOfIssue { get; set; }
        public string FatherNameFa { get; set; }
        public string FatherNameEn { get; set; }
        public byte? Sex { get; set; }
        public long? BirthCertificateNo { get; set; }
        public int? BirthCertificateSerial { get; set; }
        public int? BirthCertificateAlphabiticNoId { get; set; }
        public int? BirthCertificateNumericNo { get; set; }
        public int? DegreeId { get; set; }
        public string PostalCode { get; set; }
        public bool? IsLegal { get; set; }
        public bool? IsForeign { get; set; }
        public string NationalCardImgFront { get; set; }
        public string NationalCardImgBack { get; set; }
        public string BirthCertificateImg { get; set; }
        public string CompanyStatuteImg { get; set; }
        public string WorkPermitImg { get; set; }
        public string AnnounceLatestChangesImg { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public long Requestid { get; set; }
        public long Expr2 { get; set; }
        public string RequestData { get; set; }
        public string CommercialCode { get; set; }
        public string PassportExpireDate { get; set; }
        public string PassportNo { get; set; }
        public string ForeignPervasiveCode { get; set; }
        public string CountryCode { get; set; }
        public string NationalLegalCode { get; set; }
        public bool? VitalStatus { get; set; }
        public string ComNameFa { get; set; }
        public string ComNameEn { get; set; }
        public bool? RsidencyType { get; set; }
        public string RegisterNo { get; set; }
        public string RegisterDate { get; set; }
        public int? CityCode { get; set; }
        public string TaxPayerCode { get; set; }
    }
}
