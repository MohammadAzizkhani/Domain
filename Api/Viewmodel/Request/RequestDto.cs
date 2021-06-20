using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel.Request
{
    public class RequestDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string InstallationDate { get; set; }
        public string Description { get; set; }
        public string ShaparakDescription { get; set; }
        public byte RequestTypeId { get; set; }
        public long PspId { get; set; }
        public string Psp { get; set; }
        public byte RequestStateId { get; set; }
        public string RequestState { get; set; }
        public string RequestType { get; set; }
        public string ShaparakTrackingNumber { get; set; }
        public Guid TrackingNumber { get; set; }
        public byte ShaparakState { get; set; }
        public DateTime LastCallTime { get; set; }
        public DateTime InsertDateTime { get; set; }
        public string RequestData { get; set; }
        public string EditedBy { get; set; }
        public virtual CustomerDto Customer { get; set; }

    }
}
