using Application.Repositories;
using Domain.Common;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Model;

namespace WebAPI.Controllers.UserAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly JWTSettings _jwtsettings;
        private IConfiguration _configuration;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly AppSettings _appSettings;

        private readonly IUserLoginRepository _userloginservice;
        // private readonly IApiUserService _apiUserService;


        public LoginController(UserManager<IdentityUser> userManager,
                               SignInManager<IdentityUser> signInManager,
                               IOptions<AppSettings> appSettings1,
                               IConfiguration iConfig,
                               IOptions<JWTSettings> jwtsettings,
                               IUserLoginRepository userloginservice)
        //IApiUserService apiUserService)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings1.Value;
            _configuration = iConfig;
            _jwtsettings = jwtsettings.Value;
            _userloginservice = userloginservice;
            //_apiUserService = apiUserService;
        }



        // POST: api/Users
        [HttpPost("/api/Login")]
        [ProducesResponseType(typeof(UserLogInResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            Microsoft.AspNetCore.Identity.SignInResult myResult = new Microsoft.AspNetCore.Identity.SignInResult();
            UserLogInResponse myUserLogInResponse = new UserLogInResponse();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                //user.Password = EncryptDecrypt.Decrypt(user.Password, true, _appSettings.KeyEncrypte);

                myResult = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, lockoutOnFailure: false);


                if (!myResult.Succeeded)
                    return BadRequest("Failed to login");


                RefreshToken refreshToken = GenerateRefreshToken();

                var tempUser1 = await _userManager.FindByNameAsync(user.Username);

                var myuser = await _userloginservice.GetUserDetailsAsync(tempUser1.Id);

                myuser.myRoles.Add(new Role() { Id = 1, RoleName = "Test" });

                await _userloginservice.SaveRefreshTokenAsync(refreshToken, myuser.Id);

                myUserLogInResponse.UserName = user.Username;
                myUserLogInResponse.UserEmail = tempUser1.Email;
                myUserLogInResponse.AccessToken = GenerateAccessToken(myuser.AspId, myuser.UserName, myuser.myRoles);
                myUserLogInResponse.RefreshToken = refreshToken.Token;

                return Ok(myUserLogInResponse);

            }

            return Ok(myUserLogInResponse);
        }



        private RefreshToken GenerateRefreshToken()
        {
            RefreshToken refreshToken = new RefreshToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

            return refreshToken;
        }

        private string GenerateAccessToken(string userId, string userName, ICollection<Role> userroles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

            var mylist = new List<Claim>();

            //mylist.Add(new Claim(ClaimTypes.Name, userId));

            mylist.Add(new Claim(ClaimTypes.NameIdentifier, userId));
            mylist.Add(new Claim(ClaimTypes.GivenName, userName));

            foreach (Role item in userroles)
            {
                mylist.Add(new Claim(ClaimTypes.Role, item.RoleName));
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(mylist),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


        [HttpPost("/api/UserAuth/GetByAccessToken")]
        public async Task<UserLogInResponse> GetUserByAccessToken([FromBody] string accessToken)
        {
            return await GetUserFromAccessToken(accessToken);
        }


        private async Task<UserLogInResponse> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    var tempUser1 = await _userManager.FindByIdAsync(userId);

                    UserLogInResponse myuser = new UserLogInResponse();

                    var userAspId = User.Identity.Name;

                    var myuser1 = await _userloginservice.GetUserDetailsAsync(tempUser1.Id);

                    return myuser1;
                }
            }
            catch (Exception ex)
            {
                return new UserLogInResponse();
            }

            return new UserLogInResponse();
        }




    }
}
