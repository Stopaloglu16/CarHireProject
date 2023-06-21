using Domain.Common;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Entities.UserAuthAggregate.Register;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebSite.Services
{
    public class UserService : IUserService
    {
        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }

        public UserService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            httpClient.BaseAddress = new Uri(_appSettings.ApiAddressForDatabase);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }

        public async Task<UserLogInResponse> LoginAsync(UserLoginRequest myuser)
        {


            //myuser.Password = await UtilityClass.EncryptAsyc(myuser.Password, true, _appSettings.KeyEncrypte);

            myuser.Password = await UtilityClass.EncryptAsyc(myuser.Password, true, _appSettings.KeyEncrypte);

            string serializedUser = JsonConvert.SerializeObject(myuser);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "UserAuth/Login");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            //CustomIdentityResult mysign = new CustomIdentityResult();

            var mysign = JsonConvert.DeserializeObject<UserLogInResponse>(responseBody);


            return mysign;
        }

        public async Task<UserLogInResponse> GetUserByAccessTokenAsync(string accessToken)
        {
            string serializedRefreshRequest = JsonConvert.SerializeObject(accessToken);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/UserAuth/GetByAccessToken");
            requestMessage.Content = new StringContent(serializedRefreshRequest);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<UserLogInResponse>(responseBody);

            return await Task.FromResult(returnedUser);
        }



        public async Task<UserRegisterResponse> RegisterUserAsync(UserRegisterRequest myuser)
        {
            // PnErrorHandler myappResponse = new PnErrorHandler();

            myuser.Password = await UtilityClass.EncryptAsyc(myuser.Password, true, _appSettings.KeyEncrypte);

            string serializedUser = JsonConvert.SerializeObject(myuser);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/Register");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserRegisterResponse>(responseBody);

        }

    }
}
