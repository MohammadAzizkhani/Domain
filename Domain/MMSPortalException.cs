using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MMSPortalException : Exception
    {
        public MMSPortalException(string message) : base(message)
        {

        }

        public int Code { get; set; }
    }
}
