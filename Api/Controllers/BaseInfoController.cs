using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Viewmodel;
using Api.Viewmodel.Country;
using AutoMapper;
using Domain.Filters;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseInfoController : ControllerBase
    {
        private readonly IBaseInfoService _baseInfoService;
        private readonly IMapper _mapper;

        public BaseInfoController(IBaseInfoService baseInfoService, IMapper mapper)
        {
            _baseInfoService = baseInfoService;
            _mapper = mapper;
        }

        [HttpGet("psps")]
        public async Task<IActionResult> GetPsps()
        {
            var data = await _baseInfoService.GetPsps();

            return Ok(data);

        }

        //[HttpGet("add-psp")]
        //public async Task<IActionResult> GetPsps()
        //{
        //    var data = await _baseInfoService.GetPsps();

        //    return Ok(data);

        //}

        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects()
        {
            var data = await _baseInfoService.GetProjects();

            return Ok(data);

        }

        [HttpGet("guilds")]
        public async Task<IActionResult> GetGuilds()
        {
            var data = await _baseInfoService.GetContracts();

            return Ok(data);

        }

        [HttpGet("sub-guilds")]
        public async Task<IActionResult> GetSubGuilds()
        {
            var data = await _baseInfoService.GetMarketContract();

            return Ok(data);

        }


        [HttpGet("cities")]
        public async Task<IActionResult> GetCities([FromQuery] CityFilter filter)
        {
            var data = await _baseInfoService.GetCities(filter);

            return Ok(data);

        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries([FromQuery] CountryFilter filter)
        {
            var data = await _baseInfoService.GetCountries(filter);

            return Ok(data);

        }

        [HttpPost("add-country")]
        public async Task<IActionResult> AddCountry(AddCountryViewModel country)
        {
            var model = _mapper.Map<AddCountryViewModel, Country>(country);

            await _baseInfoService.AddCountry(model);

            return Ok();

        }

        [HttpPut("edit-country")]
        public async Task<IActionResult> EditCountry(EditCountryViewModel country)
        {
            var model = _mapper.Map<EditCountryViewModel, Country>(country);

            await _baseInfoService.EditCountry(model);

            return Ok();
        }

        [HttpDelete("remove-country")]
        public async Task<IActionResult> RemoveCountry(int countryId)
        {
            await _baseInfoService.DeleteCountry(countryId);

            return Ok();
        }
    }
}
