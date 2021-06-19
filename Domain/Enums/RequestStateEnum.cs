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
        PspPrimaryAccepted = 10,
        PspPrimaryFailed = 11,
        PspSecondaryAccepted = 12,
        PspSecondaryFailed = 13,
        PrimaryShaparakAccepted = 14,
        PrimaryShparakFailed = 15,
        ShaparakTimeOutError = 16,
        ShaparakBadDataError = 17,
        SecondaryShparakAccepted = 18,
        SecondaryShparakFailed = 19

    }
}
