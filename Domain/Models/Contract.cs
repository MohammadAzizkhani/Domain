using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public byte[] ContractDate { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public string Description { get; set; }
        public long? ProjectId { get; set; }
        public string ShareType { get; set; }
        public double? SharedAmount { get; set; }
        public long? ShareAmountMax { get; set; }
        public long? ShareAmountMin { get; set; }
        public long? Introduced { get; set; }
        public string IntroducedSharedType { get; set; }
        public long? IntroducedSharedAmount { get; set; }

        public  Customer Customer { get; set; }
        public  Project Project { get; set; }
    }
}
