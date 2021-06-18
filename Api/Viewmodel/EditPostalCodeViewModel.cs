using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Viewmodel
{
    public class EditPostalCodeViewModel
    {
        public long CustomerId { get; set; }
        [MaxLength(10)]
        public string ShopPostalCode { get; set; }
    }
}
