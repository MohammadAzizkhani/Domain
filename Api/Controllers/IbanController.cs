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
    public class IbanController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIbanService _ibanService;

        public IbanController(IMapper mapper,
            IIbanService ibanService)
        {
            _mapper = mapper;
            _ibanService = ibanService;
        }

        [HttpGet("Ibans")]
        public async Task<IActionResult> GetIbans([FromQuery] IbanCustomerFilter filter)
        {
            var data = await _ibanService.GetCustomerIbans(filter);

            return Ok(data);
        }

        [HttpPost("add-Iban")]
        public async Task<IActionResult> AddIban(List<AddIbanViewModel> addPersonViewModel)
        {
            var model = _mapper.Map<List<AddIbanViewModel>, List<CustomersIban>>(addPersonViewModel);

            await _ibanService.AddCustomerIbans(model);

            return Ok();
        }

        
    }
}
