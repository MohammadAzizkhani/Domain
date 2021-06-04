using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RolePermission
    {
        public int RoleId { get; set; }
        public long PermissionId { get; set; }
    }
}
