using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
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
    public class CustomerService : ICustomerService
    {
        private readonly MMS_PortalContext _context;

        public CustomerService(MMS_PortalContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(Person model)
        {
            var person = _context.People.FirstOrDefault(x => x.NationalNumber == model.NationalNumber && x.BirthDate == model.BirthDate);
            if (person != null)
            {
                return person;
            }
            await _context.People.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }

       

        public async Task<List<Customer>> GetCustomers(CustomerFilter filter)
        {
            var query = _context.Customers.AsQueryable();

            //var columnsMap = new Dictionary<string, Expression<Func<Customer, object>>>
            //{
            //    ["id"] = v => v.Id,
            //};

            //query = query.ApplyOrdering(filter, columnsMap);

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(x => x.Person.NationalNumber == filter.NationalId);
            }

            if (!string.IsNullOrEmpty(filter.ShopName))
            {
                query = query.Where(x => x.ShopNameEn == filter.ShopName || x.ShopNameFa == filter.ShopName);
            }
            query = query.ApplyPaging(filter);

            return await query.ToListAsync();
        }

        

        public async Task<Customer> AddCustomer(Customer model)
        {
            await _context.Customers.AddAsync(model);

            var pspList = await _context.Psps.ToListAsync();

            var requests = pspList.Select(x => new Request
            {
                CustomerId = model.Id,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                RequestData = JsonConvert.SerializeObject(model),
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id
            });

            await _context.Requests.AddRangeAsync(requests);

            await _context.SaveChangesAsync();

            return model;
        }
    }
}
