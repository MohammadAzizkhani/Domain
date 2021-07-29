using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel
{
    public class FileDto
    {
        public int Id { get; set; }
        public DateTime? InsertTime { get; set; }
        public string ContentType { get; set; }
        public string TypeName { get; set; }
    }
}
