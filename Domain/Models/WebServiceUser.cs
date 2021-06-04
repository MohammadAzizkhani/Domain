using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class WebServiceUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long? ProjectId { get; set; }
    }
}
