using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class PersonDto
    {
        public string FirstNameFa { get; set; }
        public string LastNameFa { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameEn { get; set; }
        public bool? IsLegal { get; set; }
        public bool? IsForeign { get; set; }
        public string ComNameEn { get; set; }
        public string ComNameFa { get; set; }
    }
}
