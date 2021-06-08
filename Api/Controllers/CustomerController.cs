using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Viewmodel;
using AutoMapper;
using Domain.Enums;
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

        [HttpPost("define-acceptor")]
        public async Task<IActionResult> DefineAcceptor(AddPersonViewModel addPersonViewModel)
        {
            var model = _mapper.Map<AddPersonViewModel, Person>(addPersonViewModel);

            await _customerService.AddPerson(model);

            return Ok();
        }

        [HttpGet("get-person")]
        public async Task<IActionResult> GetPerson([FromQuery] PersonType type, [FromQuery] string uniqueIdentifier)
        {
            var person = await _customerService.GetPerson(type, uniqueIdentifier);

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
        public async Task<IActionResult> EditGuild(EditGuildViewModel model)
        {
            await _customerService.EditGuild(model.CustomerId, model.GuildId);

            return Ok();
        }

        [HttpPost("edit-postalCode")]
        public async Task<IActionResult> EditPostalCode(EditPostalCodeViewModel model)
        {
            await _customerService.EditPostalCode(model.CustomerId, model.ShopPostalCode);

            return Ok();
        }

        [HttpPost("activate-terminals")]
        public async Task<IActionResult> ActivateTerminals(long customerId)
        {
            await _customerService.ActivateTerminals(customerId);

            return Ok();
        }

        [HttpPost("deactivate-terminals")]
        public async Task<IActionResult> DeactivateTerminals(long customerId)
        {
            await _customerService.DeactivateTerminals(customerId);

            return Ok();
        }

        [HttpPost("add-Iban")]
        public async Task<IActionResult> AddIban(List<AddIbanViewModel> addPersonViewModel)
        {
            var model = _mapper.Map<List<AddIbanViewModel>, List<CustomersIban>>(addPersonViewModel);

            await _customerService.AddCustomerIbans(model);

            return Ok();
        }

        [HttpGet("get-customer-ibans")]
        public async Task<IActionResult> GetCustomerIban(long customerId)
        {
            var data = await _customerService.GetCustomerIban(customerId);

            return Ok(data);
        }

        [HttpPost("change-ibans")]
        public async Task<IActionResult> ChageIbans(List<CustomersIban> ibans)
        {
            await _customerService.EditCustomerIbans(ibans);

            return Ok();
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests([FromQuery] RequestFilter filter)
        {
            var data = await _customerService.GetRequests(filter);

            return Ok(data);
        }
    }
}
