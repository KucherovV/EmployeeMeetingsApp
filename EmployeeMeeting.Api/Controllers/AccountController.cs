using AutoMapper;
using EmployeeMeeting.Api.Models.Users;
using EmployeeMeeting.Domain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeMeeting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IMapper _mapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("register")]
        public async Task<object> Register([FromBody]RegisterUserModel model)
        {
            var user = _mapper.Map<ApplicationUser>(model);

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
