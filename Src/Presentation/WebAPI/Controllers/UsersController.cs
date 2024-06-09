using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using Application.Common.Models;
using CarHire.Services.Users;
using Domain.Common;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Interfaces;
using Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly IEmailSender _emailSender;

        public UsersController(IUserService userService,
                               IOptions<AppSettings> appSettings1,
                               IEmailSender emailSender)
        {
            _userService = userService; 
            _appSettings = appSettings1.Value;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get(bool IsActive, int UserTypeId)
        {
            return await _userService.GetUsers(IsActive, UserTypeId);
        }



        [HttpGet("{Id}")]
        public async Task<UserDto> GetById(int Id)
        {
            return await _userService.GetUserById(Id);
        }


        [HttpPost]
        [Authorize(Roles = "usermanage")]
        [Route("CreateAdmin")]
        [ProducesResponseType(typeof(Ok), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<ActionResult<CreateUserResponse>> CreateAdmin(CreateAdminUserRequest user)
        {
            try
            {
                var newUser = await _userService.AddAdminUser(user);

                if (!newUser.registerToken.ToString().IsNullOrEmpty())
                {
                    await _emailSender.SendRegisterEmailAsync( user.UserEmail, user.UserEmail, newUser.registerToken.ToString());
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "usermanage")]
        [Route("CreateBranchUser")]
        public async Task<ActionResult<CreateUserResponse>> CreateBranchUser(CreateBrancUserRequest user)
        {
            try
            {
                var myReturn = await _userService.AddBranchUser(user);

                var code = await EncryptDecrypt.EncryptAsyc(user.UserEmail, true, _appSettings.KeyEncrypte);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                if (myReturn.registerToken != null)
                {
                    EmailRequest emailRequest = new() { FromMail = "" };
                    //SendEmail.SendRegister(user.UserEmail, user.UserName, code.ToString());

                    await _emailSender.SendEmailAsync(emailRequest);
                }

                return myReturn;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


      

        //[HttpPut("{Id}")]
        //public async Task<ActionResult<UpdateBranchResponse>> Update(int Id, UpdateBranchRequest branch)
        //{
        //    try
        //    {
        //        if (Id != branch.Id) return BadRequest(new UpdateBranchResponse(0, new BasicErrorHandler("Id not match")));

        //        return await _branchService.UpdateBranch(branch);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
