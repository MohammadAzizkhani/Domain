using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class PersonEditInfoRequest
    {
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
        public long? RequestId { get; set; }
    }
}
