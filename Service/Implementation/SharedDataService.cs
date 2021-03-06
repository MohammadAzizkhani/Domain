using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Domain.DbContext;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class SharedDataService : ISharedDataService
    {
        private readonly MMS_PortalContext _context;

        public SharedDataService(MMS_PortalContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCities(int provinceId)
        {
            return await _context.Cities.Where(x => x.ProvinceId == provinceId).ToListAsync();
        }

        public async Task<List<Province>> GetProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        public async Task<List<GuildCategory>> GetGuilds()
        {
            return await _context.GuildCategories.ToListAsync();
        }

        public async Task<PageCollection<GuildCategory>> GetGuildsCollection(BaseFilter filter)
        {
            var query = _context.GuildCategories.AsQueryable();

            var count = await query.CountAsync();

            query = query.ApplyPaging(filter);

            return new PageCollection<GuildCategory>
            {
                Data = await query.ToListAsync(),
                Pages = (int)Math.Ceiling((double)count / filter.PageSize),
                TotalRecord = count
            };
        }

        public async Task<List<GuildCategory>> GetGuilds(string search)
        {
            int.TryParse(search, out var code);
            return await _context.GuildCategories
                .Where(g => g.CategoryName.StartsWith(search) || g.CategoryCode == code)
                .ToListAsync();
        }

        public async Task<List<GuildSubCategory>> GetGuildsSubCategories(int categoryId)
        {
            return await _context.GuildSubCategories.Where(c => c.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Nationality>> GetNationalities(string search)
        {
            return await _context.Nationalities.Where(x => x.NationalName.StartsWith(search)).ToListAsync();
        }

        public async Task<List<Nationality>> GetNationalities()
        {
            return await _context.Nationalities.ToListAsync();
        }
        public async Task<List<Alphabitic>> GetAlphabetic()
        {
            return await _context.Alphabitics.ToListAsync();
        }
        public async Task<List<Degree>> GetDegrees()
        {
            return await _context.Degrees.ToListAsync();
        }
        public async Task<List<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<List<Country>> GetCountries(string name)
        {
            return await _context.Countries.Where(x => x.FarsiName.StartsWith(name)).ToListAsync();
        }

        public async Task<List<SharedType>> GetShareTypes()
        {
            return await _context.SharedTypes.ToListAsync();
        }

        public async Task<List<RequestState>> GetRequestStates()
        {
            return await _context.RequestStates.ToListAsync();
        }

        public async Task<List<DocType>> GetDocumentTypes()
        {
            return await _context.DocTypes.ToListAsync();
        }
    }
}
