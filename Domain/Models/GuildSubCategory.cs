using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class GuildSubCategory
    {
        public int Id { get; set; }
        public string SubCategoryTitle { get; set; }
        public string SubCategoryCode { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? Createdate { get; set; }
        public bool? Isactive { get; set; }

        public  GuildCategory Category { get; set; }
    }
}
