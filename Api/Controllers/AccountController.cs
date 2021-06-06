using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Service;
using Api.Viewmodel;
using Domain;
using Domain.Models;
using Domain.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtService _jwtService;

        public AccountController(UserManager<CustomIdentityUser> userManager,
            JwtService jwtService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                throw new MMSPortalException(LoginException.UserNotFound.GetEnumDescription())
                {
                    Code = (int)HttpStatusCode.NotFound,
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            var isLocked = await _userManager.IsLockedOutAsync(user);
            if (isLocked)
            {
                throw new MMSPortalException(LoginException.UserIsInactive.GetEnumDescription())
                {
                    Code = (int)HttpStatusCode.NotFound,
                };
            }
            if (result)
            {
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                return Ok(new { Token = _jwtService.GenerateJwtToken(user), Role = role });
            }


            throw new MMSPortalException(LoginException.UserNotFound.GetEnumDescription())
            {
                Code = (int)HttpStatusCode.NotFound,
            };
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateAccount(CreateUserViewModel user)
        {

            var identityUser = new CustomIdentityUser(user.Username)
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = true,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var isSuccess = await _userManager.CreateAsync(identityUser, user.Password);
            await _userManager.AddToRoleAsync(identityUser, user.RoleName);

            if (isSuccess == IdentityResult.Success)
                return Ok();

            throw new MMSPortalException(CreateUserException.Failed.GetEnumDescription())
            {
                Code = (int)HttpStatusCode.NotFound,
            };
        }

        [HttpGet("get-roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var data = users.Select(x => new UserDto
            {
                Email = x.Email,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                PhoneNumber = x.PhoneNumber,
                Role = _userManager.GetRolesAsync(x).Result.FirstOrDefault(),
                Username = x.UserName,
                IsActive = x.LockoutEnd == null
            });

            return Ok(data);
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (result.Succeeded)
                return Ok();

            throw new MMSPortalException(ChangePasswordException.Failed.GetEnumDescription())
            {
                Code = (int)HttpStatusCode.NotFound,
            };
        }

        [HttpPost]
        [Route("user-lock")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LockUser(UserLockViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                throw new MMSPortalException(ChangePasswordException.Failed.GetEnumDescription())
                {
                    Code = (int)HttpStatusCode.NotFound,
                };

            var result = await _userManager.SetLockoutEndDateAsync(user, DateTime.Now.AddYears(20));

            if (result.Succeeded)
                return Ok();

            throw new MMSPortalException(ChangePasswordException.Failed.GetEnumDescription())
            {
                Code = (int)HttpStatusCode.NotFound,
            };
        }

        [HttpPost]
        [Route("user-unlock")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UnlockUser(UserLockViewModel request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                return BadRequest();

            var result = await _userManager.SetLockoutEndDateAsync(user, null);

            if (result.Succeeded)
                return Ok();

            throw new MMSPortalException(ChangePasswordException.Failed.GetEnumDescription())
            {
                Code = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
