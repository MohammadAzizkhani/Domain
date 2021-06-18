using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models;
using Domain.Utility;

namespace Domain.Filters
{
    public class RequestFilter : IQueryObject
    {
        public string NationalId { get; set; }
        public string ForeignPervasiveCode { get; set; }
        public string LegalNationalCode { get; set; }
        public RequestTypeEnum? RequestType { get; set; }
        public long? PspId { get; set; }
        public string ShopName { get; set; }
        public List<byte> RequestStates { get; set; }

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
