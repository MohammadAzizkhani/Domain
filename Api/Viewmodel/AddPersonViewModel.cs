using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class AddPersonViewModel
    {
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
        public string RegisterDate { get; set; }
        public string RegisterNo { get; set; }
        public string ComNameEn { get; set; }
        public string ComNameFa { get; set; }
        public bool? RsidencyType { get; set; }
        public bool? VitalStatus { get; set; }
        public string NationalLegalCode { get; set; }
        public string CountryCode { get; set; }
        public string ForeignPervasiveCode { get; set; }
        public string PassportNo { get; set; }
        public string PassportExpireDate { get; set; }
        public string CommercialCode { get; set; }

    }
}
