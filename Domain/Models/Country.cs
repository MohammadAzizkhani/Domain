using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbrivation { get; set; }
        public string FarsiName { get; set; }
    }
}
