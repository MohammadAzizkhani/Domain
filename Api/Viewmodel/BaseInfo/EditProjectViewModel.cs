using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Api.Viewmodel.BaseInfo
{
    public class EditProjectViewModel
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public ShareTypeEnum ShareType { get; set; }
        public double? SharedAmount { get; set; }
        public long? ShareAmountMax { get; set; }
        public long? ShareAmountMin { get; set; }
    }
}
