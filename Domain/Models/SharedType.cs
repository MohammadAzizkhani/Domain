using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class SharedType
    {
        public long Id { get; set; }
        public string SahredType { get; set; }
        public byte SharedTypeCode { get; set; }
    }
}
