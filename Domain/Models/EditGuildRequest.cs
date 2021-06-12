using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class EditGuildRequest
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public int GuildId { get; set; }

        public virtual Request Request { get; set; }
    }
}
