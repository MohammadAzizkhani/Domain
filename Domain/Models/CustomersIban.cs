using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class CustomersIban
    {
        public long Id { get; set; }
        public string Iban { get; set; }
        public long? CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public byte? ShareType { get; set; }
        public double? SharedAmount { get; set; }
        public long? ShareAmountMax { get; set; }
        public long? ShareAmountMin { get; set; }
        public bool? IsMain { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
