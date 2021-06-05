using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class GuildCategory
    {
        public GuildCategory()
        {
            Customers = new HashSet<Customer>();
            GuildSubCategories = new HashSet<GuildSubCategory>();
        }

        public int Id { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public DateTime? Createdate { get; set; }
        public bool? Isactive { get; set; }

        public  ICollection<Customer> Customers { get; set; }
        public  ICollection<GuildSubCategory> GuildSubCategories { get; set; }
    }
}
