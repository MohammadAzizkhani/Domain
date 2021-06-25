using System.Collections.Generic;
using Domain.Models;

namespace Service.ViewModel
{
    public class EditRequestViewModel
    {
        public long Id { get; set; }
        public string FirstNameFa { get; set; }
        public string LastNameFa { get; set; }
        public string ComNameEn { get; set; }
        public string ComNameFa { get; set; }
        public string ShopPostalCode { get; set; }
        public string ShopTelephoneNumber { get; set; }
        public string ShopCityPreCode { get; set; }
        public string RedirectUrl { get; set; }
        public int GuildId { get; set; }
        public string TaxPayerCode { get; set; }
    }
}
