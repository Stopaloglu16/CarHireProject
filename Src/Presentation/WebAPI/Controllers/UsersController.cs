using Application.Aggregates.UserAggregate.Commands;
using Application.Aggregates.UserAggregate.Queries;
using CarHire.Services.Users;
using Domain.Common;
using Domain.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace WebAPI.Controllers
{

    public class UsersController : ApiController
    {

        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, AppSettings appSettings)
        {
            _userService = userService;
            _appSettings = appSettings;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get(bool IsActive, int UserTypeId)
        {
            return await _userService.GetUsers(IsActive, UserTypeId);
        }


        //[HttpGet("GetList")]
        //public async Task<IEnumerable<SelectListItem>> GetList()
        //{
        //    return await _branchService.GetBranchList();
        //}


        [HttpGet("{Id}")]
        public async Task<UserDto> GetById(int Id)
        {
            return await _userService.GetUserById(Id);
        }




        [HttpPost]
        [Authorize(Roles = "usermanage")]
        [Route("CreateAdmin")]
        public async Task<ActionResult<CreateUserResponse>> CreateAdmin(CreateAdminUserRequest user)
        {
            try
            {
                return await _userService.AddAdminUser(user);
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

                var code = await EncryptDecrypt.EncryptAsyc(user.UserName, true, _appSettings.KeyEncrypte);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                if (myReturn.Id > 0) { SendEmail.SendRegister(user.UserEmail, user.UserName, code.ToString()); }

                return myReturn;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<CreateUserResponse>> CreateCustomer(CreateCustomerUserRequest user)
        {
            try
            {
                return await _userService.AddCustomerUser(user);
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
