using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class ContractViewModel
    {
        public string ContractNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public string Description { get; set; }
        public long ProjectId { get; set; }
        public string ShareType { get; set; }
        public double SharedAmount { get; set; }
        public long ShareAmountMax { get; set; }
        public long ShareAmountMin { get; set; }
        public long Introduced { get; set; }
        public string IntroducedSharedType { get; set; }
        public long IntroducedSharedAmount { get; set; }
    }
}
