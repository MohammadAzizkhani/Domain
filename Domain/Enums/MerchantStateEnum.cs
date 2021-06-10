using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum MerchantStateEnum
    {
        [Description("فعال")]
        Enable = 1,
        [Description("غیر فعال")]
        Disable = 2,
        [Description("غیر فعال سپند")]
        DisableSepand = 3
    }
}
