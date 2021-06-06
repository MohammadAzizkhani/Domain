using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class MarketerContract
    {
        public int Id { get; set; }
        public byte[] ContractDate { get; set; }
        public string Description { get; set; }
        public string ShareType { get; set; }
        public double? SharedAmount { get; set; }
        public long? ShareAmountMax { get; set; }
        public long? ShareAmountMin { get; set; }
        public long? MarketerId { get; set; }
        public long? CustomerId { get; set; }
        public string Iban { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Customer Marketer { get; set; }
    }
}
