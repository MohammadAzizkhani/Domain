﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models;
using Domain.Utility;
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
            var data = await _sharedDataService.GetCities(provinceId);

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

        [HttpGet("search-nationalities")]
        public async Task<IActionResult> GetNationalities([FromQuery] string search)
        {
            var data = await _sharedDataService.GetNationalities(search);

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

        [HttpGet("person-type")]
        public IActionResult GetPersonType()
        {
            return Ok(new List<object>
            {
                new {Id = (int)PersonType.RealPerson, Name = PersonType.RealPerson.GetEnumDescription()},
                new {Id = (int)PersonType.LegalPerson, Name = PersonType.LegalPerson.GetEnumDescription()},
                new {Id = (int)PersonType.Foreign, Name = PersonType.Foreign.GetEnumDescription()}
            });
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var data = await _sharedDataService.GetCountries();

            return Ok(data);
        }

        [HttpGet("search-countries")]
        public async Task<IActionResult> GetCountries(string name)
        {
            var data = await _sharedDataService.GetCountries(name);

            return Ok(data);
        }

        [HttpGet("share-type")]
        public IActionResult GetShareType()
        {
            return Ok(new List<object>
            {
                new
                {
                    Id = (int)ShareTypeEnum.Percentage,
                    Name = ShareTypeEnum.Percentage.GetEnumDescription(),
                    sharedTypeCode =(int)ShareTypeEnum.Percentage
                },
                new
                {
                    Id = (int)ShareTypeEnum.Amount, 
                    Name = ShareTypeEnum.Amount.GetEnumDescription(),
                    sharedTypeCode =(int)ShareTypeEnum.Amount
                }
            });
        }
    }
}
