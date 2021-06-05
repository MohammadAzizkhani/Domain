using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RequestHistory
    {
        public long Id { get; set; }
        public long? RequestId { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public byte? ShaparakState { get; set; }
        public string ShaparakDescription { get; set; }
        public byte? RequestState { get; set; }
        public string ShaparakTrackingNumber { get; set; }
        public Guid? TrackingNumber { get; set; }

        public  Request Request { get; set; }
    }
}
