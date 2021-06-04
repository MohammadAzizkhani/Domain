using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class MerchantSyncTable
    {
        public long Id { get; set; }
        public long? Merchantid { get; set; }
        public byte? SyncType { get; set; }
        public bool? Issynced { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Syncdate { get; set; }
    }
}
