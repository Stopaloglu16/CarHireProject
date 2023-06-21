using Blazored.LocalStorage;
using WebUI.Services;
using Domain.Entities.RoleAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebUI.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        public ILocalStorageService _localStorageService { get; }
        public IUserService _userService { get; set; }
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,
            IUserService userService,
            HttpClient httpClient)
        {
            //throw new Exception("CustomAuthenticationStateProviderException");
            _localStorageService = localStorageService;
            _userService = userService;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");

            ClaimsIdentity identity;

            if (accessToken != null && accessToken != string.Empty)
            {
                UserLogInResponse user = await _userService.GetUserByAccessTokenAsync(accessToken);
                identity = GetClaimsIdentity(user);

                //var claims = new List<Claim>
                //        {
                //            new Claim(ClaimTypes.Name, "John Doe"),
                //            new Claim(ClaimTypes.Role, "Administrator")
                //        };

                //identity = new ClaimsIdentity(claims, "testAuthType");

            }
            else
            {
                identity = new ClaimsIdentity();
            }

            //identity = new ClaimsIdentity();

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }



        public void MarkUserAsAuthenticated(UserLogInResponse user)
        {

            _localStorageService.SetItemAsync("accessToken", user.AccessToken);
            _localStorageService.SetItemAsync("refreshToken", user.RefreshToken);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "test")
                };

            var anonymous = new ClaimsIdentity(claims, "testAuthType");
            var myuser = new ClaimsPrincipal(anonymous);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(myuser)));



            //await _localStorageService.SetItemAsync("accessToken", user.AccessToken);
            //await _localStorageService.SetItemAsync("refreshToken", user.RefreshToken);

            //var claims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, user.UserName),
            //        new Claim(ClaimTypes.Role, "Administrator")
            //    };

            //var anonymous = new ClaimsIdentity(claims, "testAuthType");
            //await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));

        }

        public async Task MarkUserAsLoggedOut()
        {
            await _localStorageService.RemoveItemAsync("refreshToken");
            await _localStorageService.RemoveItemAsync("accessToken");

            var identity = new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(UserLogInResponse user)
        {
            var claimsIdentity = new ClaimsIdentity();

            if (user.UserEmail != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Name, user.UserName)
                                    //new Claim(ClaimTypes.Role, "Add art"),
                                    //new Claim(ClaimTypes.Role, "Add movie"),
                                    //new Claim("IsUserEmployedBefore1990", IsUserEmployedBefore1990(user))
                                }, "apiauth_type");
            }

            if (user.myRoles != null)
            {
                foreach (Role role in user.myRoles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
                }
            }

            return claimsIdentity;
        }
    }
}
