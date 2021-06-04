using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RequestType
    {
        public RequestType()
        {
            Requests = new HashSet<Request>();
        }

        public byte Id { get; set; }
        public string Request { get; set; }
        public string PspRequestTitle { get; set; }
        public byte? PspRequestCode { get; set; }
        public string ShaparakSatetTitle { get; set; }
        public byte? ShaparakSatetCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
