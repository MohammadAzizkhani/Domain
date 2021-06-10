using System.ComponentModel;

namespace Domain.Enums
{
    public enum ShareTypeEnum
    {
        [Description("درصدی")]
        Percentage = 1,

        [Description("ثابت")]
        Amount = 2,
    }
}
