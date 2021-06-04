using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Permission
    {
        public long Id { get; set; }
        public string Permission1 { get; set; }
        public string Description { get; set; }
    }
}
