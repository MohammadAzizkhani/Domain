using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public  ICollection<User> Users { get; set; }
    }
}
