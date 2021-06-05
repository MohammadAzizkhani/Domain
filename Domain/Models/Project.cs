using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Project
    {
        public Project()
        {
            Contracts = new HashSet<Contract>();
        }

        public long Id { get; set; }
        public string ProjectName { get; set; }
        public string ShareType { get; set; }
        public double? SharedAmount { get; set; }
        public long? ShareAmountMax { get; set; }
        public long? ShareAmountMin { get; set; }

        public  ICollection<Contract> Contracts { get; set; }
    }
}
