using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;

namespace Service.Interface
{
    public interface IBaseInfoService
    {
        Task AddCountry(Country country);
        Task<PageCollection<Country>> GetCountries(CountryFilter filter);
        Task EditCountry(Country country);
        Task DeleteCountry(int id);

        Task<PageCollection<City>> GetCities(CityFilter filter);

        Task<List<Psp>> GetPsps();
        Task AddPsp(Psp psp);
        Task EditPsp(Psp psp);
        Task DeletePsp(int id);
        Task<List<Contract>> GetContracts();
        Task<List<Project>> GetProjects();
        Task<List<MarketerContract>> GetMarketContract();



    }
}
