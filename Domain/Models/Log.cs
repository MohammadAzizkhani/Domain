using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Log
    {
        public long Id { get; set; }
        public string FunctionName { get; set; }
        public string ResponseCode { get; set; }
        public long? Rrn { get; set; }
        public long? TerminalId { get; set; }
        public long? MerchantId { get; set; }
        public string TerminalDateTime { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
