using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Request
    {
        public Request()
        {
            EditGuildRequests = new HashSet<EditGuildRequest>();
            EditIbanRequests = new HashSet<EditIbanRequest>();
            EditPostalCodeRequests = new HashSet<EditPostalCodeRequest>();
            NewGuildAndPostalCodeRequests = new HashSet<NewGuildAndPostalCodeRequest>();
            NewIbanRequests = new HashSet<NewIbanRequest>();
            RequestDetails = new HashSet<RequestDetail>();
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
        public string EditedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Psp Psp { get; set; }
        public virtual RequestState RequestState { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual ICollection<EditGuildRequest> EditGuildRequests { get; set; }
        public virtual ICollection<EditIbanRequest> EditIbanRequests { get; set; }
        public virtual ICollection<EditPostalCodeRequest> EditPostalCodeRequests { get; set; }
        public virtual ICollection<NewGuildAndPostalCodeRequest> NewGuildAndPostalCodeRequests { get; set; }
        public virtual ICollection<NewIbanRequest> NewIbanRequests { get; set; }
        public virtual ICollection<RequestDetail> RequestDetails { get; set; }
        public virtual ICollection<RequestHistory> RequestHistories { get; set; }
    }
}
