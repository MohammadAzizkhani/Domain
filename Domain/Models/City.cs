using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string CityName { get; set; }
        public string EnglishCityName { get; set; }
        public string TosanCityCodeNew { get; set; }
        public DateTime? Createdate { get; set; }
        public bool? Isactive { get; set; }
        public string OldCode { get; set; }
    }
}
