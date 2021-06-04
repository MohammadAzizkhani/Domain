using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Psp
    {
        public Psp()
        {
            Merchants = new HashSet<Merchant>();
            Requests = new HashSet<Request>();
        }

        public long Id { get; set; }
        public string UserShaparak { get; set; }
        public string PasswordShaparak { get; set; }
        public string PspMmsUsername { get; set; }
        public string PspMmsPassword { get; set; }
        public string PspMmsPublicKey { get; set; }
        public string PspMmsPrivateKey { get; set; }
        public string ShaparakFtpPublicKey { get; set; }
        public string ShaparakFtpPrivateKey { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ShaparakFtpUsername { get; set; }
        public string ShaparakFtpPassword { get; set; }
        public string Iin { get; set; }
        public string TerminalNo { get; set; }
        public string AcceptorCode { get; set; }
        public byte? StepsCount { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
