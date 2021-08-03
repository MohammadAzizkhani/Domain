using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Service;
using Api.Viewmodel;
using Api.Viewmodel.Request;
using AutoMapper;
using Domain;
using Domain.Enums;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Service.Interface;
using Service.ViewModel;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly JwtService _jwtService;

        public CustomerController(IMapper mapper,
            ICustomerService customerService,
            JwtService jwtService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _jwtService = jwtService;
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

        [HttpGet("get-customer-ibans")]
        public async Task<IActionResult> GetCustomerIban(long customerId)
        {
            var data = await _customerService.GetCustomerIban(customerId);

            var result = _mapper.Map<List<CustomersIban>, List<IbanDto>>(data);

            return Ok(result);
        }

        [HttpPost("change-ibans")]
        public async Task<IActionResult> ChageIbans(List<AddIbanViewModel> addPersonViewModel)
        {
            var model = _mapper.Map<List<AddIbanViewModel>, List<CustomersIban>>(addPersonViewModel);

            await _customerService.EditCustomerIbans(model);

            return Ok();
        }

        [HttpGet("first-registration")]
        public async Task<IActionResult> GetFirstStepRequests([FromQuery] RequestFilter filter)
        {
            filter.RequestStates = new List<byte>
            {
                (byte) RequestStateEnum.SuccessRegistration
            };

            var data = await _customerService.GetRequests(filter);

            var result = _mapper.Map<PageCollection<Request>, PageCollection<RequestDto>>(data);

            return Ok(result);
        }


        [HttpGet("sent-to-psp")]
        public async Task<IActionResult> GetSecondStepRequests([FromQuery] RequestFilter filter)
        {
            filter.RequestStates = new List<byte>
            {
                (byte) RequestStateEnum.PspPrimaryAccepted,
                (byte) RequestStateEnum.PspPrimaryFailed,
                (byte) RequestStateEnum.PspSecondaryFailed,
            };

            var data = await _customerService.GetRequests(filter);
            var result = _mapper.Map<PageCollection<Request>, PageCollection<RequestDto>>(data);

            return Ok(result);
        }

        [HttpGet("shaparak-process")]
        public async Task<IActionResult> GetThirdStepRequests([FromQuery] RequestFilter filter)
        {
            filter.RequestStates = new List<byte>
            {
                (byte) RequestStateEnum.PspSecondaryAccepted,
                (byte) RequestStateEnum.ShaparakBadDataError,
                (byte) RequestStateEnum.PrimaryShaparakAccepted,
                (byte) RequestStateEnum.PrimaryShparakFailed,
                (byte) RequestStateEnum.ShaparakTimeOutError,
            };

            var data = await _customerService.GetRequests(filter);
            var result = _mapper.Map<PageCollection<Request>, PageCollection<RequestDto>>(data);

            return Ok(result);
        }

        [HttpGet("completed-requests")]
        public async Task<IActionResult> GetFinalStepRequests([FromQuery] RequestFilter filter)
        {
            filter.RequestStates = new List<byte>
            {
                (byte) RequestStateEnum.SecondaryShparakAccepted
            };

            var data = await _customerService.GetRequests(filter);
            var result = _mapper.Map<PageCollection<Request>, PageCollection<RequestDto>>(data);

            return Ok(result);
        }

        [HttpPost("start-edit")]
        public async Task<IActionResult> StartEditRequest([FromBody] long requestId)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];

            var username = _jwtService.GetUsername(token);

            await _customerService.StartEditRequest(requestId, username);

            return Ok();
        }

        [HttpPut("edit-request")]
        public async Task<IActionResult> EditRequest([FromBody] EditRequestViewModel vm)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];

            var username = _jwtService.GetUsername(token);

            await _customerService.EditRequest(vm, username);

            return Ok();
        }

        [HttpDelete("remove-request")]
        public async Task<IActionResult> RemoveRequest(long id)
        {
            await _customerService.RemoveRequest(id);

            return Ok();
        }



        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileViewModel viewModel)
        {
            if (viewModel.FormFile.Length == 0)
            {
                throw new MMSPortalException("please upload valid file");
            }
            if (viewModel.FormFile.Length > 5_245_000)
            {
                throw new MMSPortalException("File too large");
            }

            var obj = _mapper.Map<UploadFileViewModel, Document>(viewModel);
            await _customerService.UploadFile(obj);
            return Ok();
        }


        [HttpGet("download-file")]
        public async Task<IActionResult> DownloadFile([FromQuery] int id)
        {
            var document = await _customerService.DownloadFile(id);
            var data = document.Data;
            return File(data, document.ContentType);
        }

        [HttpGet("customer-files")]
        public async Task<IActionResult> GetCustomerFiles([FromQuery] int customerId)
        {
            var document = await _customerService.GetCustomerFiles(customerId);

            return Ok(document);
        }
    }
}
