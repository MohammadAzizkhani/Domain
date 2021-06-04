using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class State
    {
        public int Id { get; set; }
        public string DataInserted { get; set; }
        public string PspAccepted { get; set; }
    }
}
