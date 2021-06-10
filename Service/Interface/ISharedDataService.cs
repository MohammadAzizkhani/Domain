using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Interface
{
    public interface ISharedDataService
    {
        Task<List<City>> GetCities(int provinceId);
        Task<List<Province>> GetProvinces();
        Task<List<GuildCategory>> GetGuilds();
        Task<List<GuildSubCategory>> GetGuildsSubCategories(int categoryId);
        Task<List<Nationality>> GetNationalities(string search);
        Task<List<Nationality>> GetNationalities();
        Task<List<Alphabitic>> GetAlphabetic();
        Task<List<Degree>> GetDegrees();
        Task<List<Country>> GetCountries();
        Task<List<Country>> GetCountries(string name);
        Task<List<SharedType>> GetShareTypes();
    }
}
