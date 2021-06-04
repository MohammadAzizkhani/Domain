using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Province
    {
        public int ProvinceId { get; set; }
        public int ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceAbbreviation { get; set; }
        public string TellCode { get; set; }
        public int? CountryId { get; set; }
    }
}
