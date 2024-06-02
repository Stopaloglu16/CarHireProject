using CarHire.Services.UserAuths;
using Domain.Common;
using Domain.Entities.UserAuthAggregate.Register;
using Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers.UserAuth
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IUserRegisterService _userregisterservice;

        public RegisterController(
                         UserManager<IdentityUser> userManager,
                         IOptions<AppSettings> appSettings1,
                         IConfiguration iConfig,
                         IUserRegisterService userregisterservice)
        {
            _userManager = userManager;
            _appSettings = appSettings1.Value;
            _configuration = iConfig;
            _userregisterservice = userregisterservice;
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserRegisterResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequest userRegister)
        {

            UserRegisterResponse userRegisterResponse = new UserRegisterResponse(0);

            var myUser = await _userregisterservice.GetUserByAsync(userRegister.Username, userRegister.TokenConfirm);

            if (myUser != null)
            {

                DateTime myNow = DateTime.Now;
                int tt = myNow.Subtract(myUser.RegisterTokenValid).Days;

                if (tt >= 1)
                    return BadRequest("Token is expired");


                var myIduser = new IdentityUser { UserName = userRegister.Username, Email = myUser.UserEmail };

                userRegister.Password = EncryptDecrypt.Decrypt(userRegister.Password, true, _appSettings.KeyEncrypte);
                myIduser.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(myIduser, userRegister.Password);

                if (result.Succeeded)
                {
                    await _userregisterservice.UpdateUserAsync(myUser.Id, myIduser.Id);

                    return Ok(new UserRegisterResponse(myUser.Id));
                }

                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Description);
                }

                return BadRequest("System issue");

            }
            else
            {
                return BadRequest("User not found");
            }

        }


        //public async Task<UserRegisterResponse> RegisterUser1(int _userId, string _UserName, string _UserEmail, string _UserPassword)
        //{
        //    var myIduser = new IdentityUser { UserName = _UserName, Email = _UserEmail };

        //    _UserPassword = UtilityClass.Decrypt(_UserPassword, true, _appSettings.KeyEncrypte);
        //    myIduser.EmailConfirmed = true;

        //    var result = await _userManager.CreateAsync(myIduser, _UserPassword);

        //    if (result.Succeeded)
        //    {
        //        await _userregisterservice.UpdateUserAsync(_userId, myIduser.Id);

        //        return new UserRegisterResponse(_userId, new BasicErrorHandler());
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            return new UserRegisterResponse(0, new BasicErrorHandler(error.Description));
        //        }

        //        return new UserRegisterResponse(0, new BasicErrorHandler("Error"));
        //    }

        //}


    }
}
