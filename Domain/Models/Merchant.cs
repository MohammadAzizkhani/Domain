﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Merchant
    {
        public long Id { get; set; }
        public long? PspId { get; set; }
        public string AcceptorCode { get; set; }
        public string TerminalNo { get; set; }
        public long? CustomerId { get; set; }
        public byte? Status { get; set; }
        public int? TerminalType { get; set; }

        public  Customer Customer { get; set; }
        public  Psp Psp { get; set; }
        public  TerminalType TerminalTypeNavigation { get; set; }
    }
}
