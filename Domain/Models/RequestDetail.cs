using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RequestDetail
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public string Data { get; set; }

        public virtual Request Request { get; set; }
    }
}
