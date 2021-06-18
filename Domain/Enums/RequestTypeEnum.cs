using System.ComponentModel;

namespace Domain.Enums
{
    public enum RequestTypeEnum : byte
    {
        [Description("تعریف پذیرنده")]
        MerchantRegister = 1,
        [Description("تغییر شبا")]
        ChangeIban = 2,
        [Description("تغییر صنف")]
        ChangeGuild = 3,
        [Description("تغییر کدپستی")]
        ChangePostalCode = 4,
        [Description("غیر فعال سازی ترمینال")]
        TerminalDeactivation = 5,
        [Description("فعال سازی ترمینال")]
        TerminalActivation = 6,
        ChangeCustomer = 7,
    }
}
