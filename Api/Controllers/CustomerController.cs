using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Viewmodel;
using AutoMapper;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper,
            ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpPost("add-person")]
        public async Task<IActionResult> AddPerson(AddPersonViewModel addPersonViewModel)
        {
            var model = _mapper.Map<AddPersonViewModel, Person>(addPersonViewModel);

            var person = await _customerService.AddPerson(model);

            return Ok(person);
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer(AddCustomerViewModel addCustomerViewModel)
        {
            var model = _mapper.Map<AddCustomerViewModel, Customer>(addCustomerViewModel);

            var customer = await _customerService.AddCustomer(model);

            return Ok(customer);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers([FromQuery] CustomerFilter filter)
        {
            var customers = await _customerService.GetCustomers(filter);

            var data = _mapper.Map<PageCollection<Customer>, PageCollection<CustomerDto>>(customers);

            return Ok(data);
        }


        [HttpPost("edit-guild")]
        public async Task<IActionResult> EditGuild(EditGuildViewModel filter)
        {
            await _customerService.EditGuild(filter.CustomerId, filter.GuildId);

            return Ok();
        }
    }
}
