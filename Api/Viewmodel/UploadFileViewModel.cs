using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Viewmodel
{
    public class UploadFileViewModel
    {
        public int DocTypeId { get; set; }
        public long  CustomerId { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
