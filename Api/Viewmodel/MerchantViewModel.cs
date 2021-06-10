using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class MerchantViewModel
    {
        public string AcceptorCode { get; set; }
        public string TerminalNo { get; set; }
        public long? CustomerId { get; set; }
        public byte? Status { get; set; }
        public string StatusTitle { get; set; }
        public int? TerminalType { get; set; }
    }
}
