using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class SharedDataController : ControllerBase
    {
        private readonly ISharedDataService _sharedDataService;

        public SharedDataController(ISharedDataService sharedDataService)
        {
            _sharedDataService = sharedDataService;
        }


        [HttpGet("cities")]
        public async Task<IActionResult> GetCities(int provinceId)
        {
            var data  = await _sharedDataService.GetCities(provinceId);

            return Ok(data);
        }

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var data = await _sharedDataService.GetProvinces();

            return Ok(data);
        }

        [HttpGet("guilds-categories")]
        public async Task<IActionResult> GetGuilds()
        {
            var data = await _sharedDataService.GetGuilds();

            return Ok(data);
        }

        [HttpGet("guilds-sub-categories")]
        public async Task<IActionResult> GetGuildSubcategories(int categoryId)
        {
            var data = await _sharedDataService.GetGuildsSubCategories(categoryId);

            return Ok(data);
        }

        [HttpGet("nationalities")]
        public async Task<IActionResult> GetNationalities()
        {
            var data = await _sharedDataService.GetNationalities();

            return Ok(data);
        }

        [HttpGet("alphabets")]
        public async Task<IActionResult> GetAlphabets()
        {
            var data = await _sharedDataService.GetAlphabetic();

            return Ok(data);
        }

        [HttpGet("degrees")]
        public async Task<IActionResult> GetDegrees()
        {
            var data = await _sharedDataService.GetDegrees();

            return Ok(data);
        }
    }
}
