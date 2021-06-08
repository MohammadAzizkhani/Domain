using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel.Country
{
    public class EditCountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbrivation { get; set; }
        public string FarsiName { get; set; }
    }
}
