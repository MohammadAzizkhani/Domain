using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum RequestStateEnum : byte
    {
        [Description("ثبت موفق")]
        SuccessRegistration = 1,
        [Description("خطا در ثبت")]
        FailedRegistration = 2,
        [Description("تایید اولیه psp")]
        PspPrimaryAccepted = 10,
        [Description("خطا در تایید اولیه psp")]
        PspPrimaryFailed = 11,
        [Description("تایید ثانویه psp")]
        PspSecondaryAccepted = 12,
        [Description("خطا در تایید ثانویه psp")]
        PspSecondaryFailed = 13,
        [Description("تایید اولیه شاپرک")]
        PrimaryShaparakAccepted = 14,
        [Description("خطا در تایید اولیه شاپرک")]
        PrimaryShparakFailed = 15,
        [Description("تایم اوت شاپرک")]
        ShaparakTimeOutError = 16,
        [Description("Shaparak BadData")]
        ShaparakBadDataError = 17,
        [Description("Secondary Shparak Accepted")]
        SecondaryShparakAccepted = 18,
        [Description("Secondary Shparak Failed")]
        SecondaryShparakFailed = 19

    }
}
