using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DbContext;
using Domain.Enums;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Service.Interface;

namespace Service.Implementation
{
    public class IbanService : IIbanService
    {
        private readonly MMS_PortalContext _context;

        public IbanService(MMS_PortalContext context)
        {
            _context = context;
        }
        public async Task AddCustomerIbans(List<CustomersIban> ibans)
        {
            await _context.CustomersIbans.AddRangeAsync(ibans);

            var requests = ibans.Select(x => new Request
            {
                CustomerId = x.CustomerId,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                RequestData = JsonConvert.SerializeObject(x),
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomersIban>> GetCustomerIbans(IbanCustomerFilter model)
        {
            //var columnsMap = new Dictionary<string, Expression<Func<CustomersIban, object>>>
            //{
            //    ["make"] = v => v.,
            //    ["model"] = v => v.Model.Name,
            //    ["contactName"] = v => v.ContactName
            //};
            var query = _context.CustomersIbans.AsQueryable();

            if (!string.IsNullOrEmpty(model.NationalId))
            {
                query = query.Where(x => x.Customer.Person.NationalNumber == model.NationalId);
            }
            query = query.ApplyPaging(model);

            return await query.ToListAsync();
        }
    }
}
