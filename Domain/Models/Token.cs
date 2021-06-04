using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Token
    {
        public long Id { get; set; }
        public DateTime? TokenIssueDate { get; set; }
        public string Token1 { get; set; }
        public string UserName { get; set; }
        public bool? TokenIsVerified { get; set; }
        public DateTime? TokenVerifiedDate { get; set; }
    }
}
