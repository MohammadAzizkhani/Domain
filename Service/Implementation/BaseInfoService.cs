﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class BaseInfoService : IBaseInfoService
    {
        private readonly MMS_PortalContext _context;

        public BaseInfoService(MMS_PortalContext context)
        {
            _context = context;
        }

        public async Task AddCountry(Country country)
        {
            await _context.Countries.AddAsync(country);
        }

        public async Task<PageCollection<Country>> GetCountries(CountryFilter filter)
        {
            var query = _context.Countries.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.FarsiName.StartsWith(filter.Name));
            }

            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            var data = await query.ToListAsync();

            return new PageCollection<Country>
            {
                Data = data,
                Pages = (int)Math.Ceiling((double)count / filter.PageSize),
                TotalRecord = count
            };
        }

        public async Task EditCountry(Country country)
        {
            var dbObject = await _context.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);

            if (dbObject == null)
                throw new MMSPortalException(GeneralException.NotFound.GetEnumDescription());

            dbObject.FarsiName = country.FarsiName;
            dbObject.Abbrivation = country.Abbrivation;
            dbObject.Code = country.Code;
            dbObject.Name = country.Name;

            _context.Countries.Update(dbObject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountry(int id)
        {
            var dbObject = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (dbObject == null)
                throw new MMSPortalException(GeneralException.NotFound.GetEnumDescription());

            _context.Countries.Remove(dbObject);
            await _context.SaveChangesAsync();
        }

        public async Task<PageCollection<City>> GetCities(CityFilter filter)
        {
            var query = _context.Cities.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.CityName.StartsWith(filter.Name));
            }

            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            var data = await query.ToListAsync();

            return new PageCollection<City>
            {
                Data = data,
                Pages = (int)Math.Ceiling((double)count / filter.PageSize),
                TotalRecord = count
            };
        }

        public async Task<List<Psp>> GetPsps()
        {
            return await _context.Psps.ToListAsync();
        }

        public async Task AddPsp(Psp psp)
        {
            await _context.Psps.AddAsync(psp);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contract>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<List<MarketerContract>> GetMarketContract()
        {
            return await _context.MarketerContracts.ToListAsync();
        }
    }
}
