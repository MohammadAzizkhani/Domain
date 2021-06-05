using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Utility
{
    public class PageCollection<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecord { get; set; }
        public int Pages { get; set; }
    }
}
