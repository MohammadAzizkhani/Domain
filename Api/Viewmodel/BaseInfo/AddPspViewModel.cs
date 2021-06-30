using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel.BaseInfo
{
    public class AddPspViewModel
    {
        [MaxLength(50)]
        public string UserShaparak { get; set; }
        [MaxLength(50)]
        public string PasswordShaparak { get; set; }
        [MaxLength(50)]
        public string PspMmsUsername { get; set; }
        [MaxLength(50)]
        public string PspMmsPassword { get; set; }
        public string PspMmsPublicKey { get; set; }
        public string PspMmsPrivateKey { get; set; }
        public string ShaparakFtpPublicKey { get; set; }
        public string ShaparakFtpPrivateKey { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Alias { get; set; }
        [MaxLength(50)]
        public string ShaparakFtpUsername { get; set; }
        [MaxLength(50)]
        public string ShaparakFtpPassword { get; set; }
        [MaxLength(10)]
        public string Iin { get; set; }
        [MaxLength(8)]
        public string TerminalNo { get; set; }
        [MaxLength(15)]
        public string AcceptorCode { get; set; }
    }
}
