using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class RequestState
    {
        public RequestState()
        {
            Requests = new HashSet<Request>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
