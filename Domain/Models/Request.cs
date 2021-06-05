using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Request
    {
        public Request()
        {
            NewGuildAndPostalCodeRequests = new HashSet<NewGuildAndPostalCodeRequest>();
            NewIbanRequests = new HashSet<NewIbanRequest>();
            RequestHistories = new HashSet<RequestHistory>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string InstallationDate { get; set; }
        public string Description { get; set; }
        public string ShaparakDescription { get; set; }
        public byte? RequestTypeId { get; set; }
        public long? PspId { get; set; }
        public byte? RequestStateId { get; set; }
        public string ShaparakTrackingNumber { get; set; }
        public Guid? TrackingNumber { get; set; }
        public byte? ShaparakState { get; set; }
        public DateTime? LastCallTime { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string RequestData { get; set; }

        public  Customer Customer { get; set; }
        public  Psp Psp { get; set; }
        public  RequestState RequestState { get; set; }
        public  RequestType RequestType { get; set; }
        public  ICollection<NewGuildAndPostalCodeRequest> NewGuildAndPostalCodeRequests { get; set; }
        public  ICollection<NewIbanRequest> NewIbanRequests { get; set; }
        public  ICollection<RequestHistory> RequestHistories { get; set; }
    }
}
