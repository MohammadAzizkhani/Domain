using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DbContext;
using Domain.Models;
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

        public async Task<List<GuildSubCategory>> GetGuildsSubCategories(int categoryId)
        {
            return await _context.GuildSubCategories.Where(c => c.CategoryId == categoryId).ToListAsync();
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
    }
}
