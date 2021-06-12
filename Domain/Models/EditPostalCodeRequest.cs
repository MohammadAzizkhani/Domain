using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class EditPostalCodeRequest
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public string PostalCode { get; set; }

        public virtual Request Request { get; set; }
    }
}
