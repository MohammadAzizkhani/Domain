using Domain.Utility;

namespace Domain.Filters
{
    public class CustomerFilter : IQueryObject
    {
        public string NationalId { get; set; }
        public string ShopName { get; set; }

        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
