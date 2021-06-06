using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class NewGuildAndPostalCodeRequest
    {
        public long Id { get; set; }
        public int? GuildId { get; set; }
        public string PostalCode { get; set; }
        public long? RequestId { get; set; }
        public long? CustomerId { get; set; }
        public long? PspId { get; set; }

        public virtual Request Request { get; set; }
    }
}
