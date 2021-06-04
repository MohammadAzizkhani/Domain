using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class UsersPermission
    {
        public long UserId { get; set; }
        public long PermissionId { get; set; }
    }
}
