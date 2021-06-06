using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class TerminalType
    {
        public TerminalType()
        {
            Merchants = new HashSet<Merchant>();
        }

        public int TerminalTypeCode { get; set; }
        public string TerminalTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Merchant> Merchants { get; set; }
    }
}
