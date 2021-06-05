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
            Person person = null;
            if (model.IsForeign.HasValue)
            {
                if (!model.IsForeign.Value)
                {
                    if (model.IsLegal.HasValue && model.IsLegal.Value)
                    {
                        person = _context.People.FirstOrDefault(x => x.RegisterNo == model.RegisterNo);
                    }
                    else
                    {
                        person = _context.People.FirstOrDefault(x => x.NationalNumber == model.NationalNumber);
                    }
                }
                else
                {
                    person = _context.People.FirstOrDefault(x => x.ForeignPervasiveCode == model.ForeignPervasiveCode);
                }
            }

            if (person != null)
            {
                return person;
            }

            await _context.People.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }



        public async Task<PageCollection<Customer>> GetCustomers(CustomerFilter filter)
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
            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            var data = await query.ToListAsync();



            return new PageCollection<Customer>
            {
                Data = data,
                Pages = count / filter.PageSize,
                TotalRecord = count
            };

        }



        public async Task<Customer> AddCustomer(Customer model)
        {
            var pspList = await _context.Psps.ToListAsync();

            model.Requests = pspList.Select(x => new Request
            {
                CustomerId = model.Id,
                InsertDateTime = DateTime.Now,
                RequestTypeId = (byte)RequestTypeEnum.MerchantRegister,
                TrackingNumber = Guid.NewGuid(),
                PspId = x.Id
            }).ToList();

            await _context.Customers.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;
        }
    }
}
