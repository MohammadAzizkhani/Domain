using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class EditIbanRequest
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public string Iban { get; set; }

        public virtual Request Request { get; set; }
    }
}
