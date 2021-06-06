using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Viewmodel;
using AutoMapper;
using Domain.Filters;
using Domain.Models;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class BaseInfoController : ControllerBase
    {
        private readonly IBaseInfoService _baseInfoService;

        public BaseInfoController(IBaseInfoService baseInfoService)
        {
            _baseInfoService = baseInfoService;
        }

        [HttpPost("psps")]
        public async Task<IActionResult> GetPsps()
        {
            var data = await _baseInfoService.GetPsps();

            return Ok(data);

        }

        [HttpPost("projects")]
        public async Task<IActionResult> GetProjects()
        {
            var data = await _baseInfoService.GetProjects();

            return Ok(data);

        }

        [HttpPost("contracts")]
        public async Task<IActionResult> GetPContracts()
        {
            var data = await _baseInfoService.GetContracts();

            return Ok(data);

        }

        [HttpPost("marketer-contract")]
        public async Task<IActionResult> GetMarketerContract()
        {
            var data = await _baseInfoService.GetMarketContract();

            return Ok(data);

        }

    }
}
