using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public long? CustomerId { get; set; }
        public int? DocTypeId { get; set; }
        public byte[] Data { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
