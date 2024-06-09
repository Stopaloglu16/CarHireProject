using Application.Aggregates.UserAggregate.Commands;
using CarHire.Services.Users;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.UserAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public SignupController(IUserService userService,
                               AppSettings appSettings,
                               IEmailSender emailSender)
        {
            _userService = userService;
            _appSettings = appSettings;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("CreateCustomer")]
        [ProducesResponseType(typeof(CreateUserResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerUserRequest user)
        {
            try
            {
                var userResponse = await _userService.AddCustomerUser(user);

                //if(userResponse != null)
                //SendEmail(userResponse.)

                return Ok(userResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
