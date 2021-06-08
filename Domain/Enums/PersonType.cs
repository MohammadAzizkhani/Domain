using System.ComponentModel;

namespace Domain.Enums
{
    public enum PersonType
    {
        [Description("حقیقی")]
        RealPerson = 1,

        [Description("حقوقی")]
        LegalPerson = 2,

        [Description("اتباع")]
        Foreign = 3
    }
}
