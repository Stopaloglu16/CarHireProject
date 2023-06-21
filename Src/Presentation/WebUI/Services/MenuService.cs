using Blazored.LocalStorage;
using Domain.Common;
using Domain.Entities.MenuAggregate;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebUI.Services
{
    public class MenuService : IMenuService
    {

        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        public ILocalStorageService _localStorageService { get; }

        public MenuService(HttpClient httpClient
            , IOptions<AppSettings> appSettings
            , ILocalStorageService localStorageService)
        {
            _appSettings = appSettings.Value;
            _localStorageService = localStorageService;

            httpClient.BaseAddress = new Uri(_appSettings.ApiAddressForDatabase);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }


        public async Task<List<WebMenu>> GetWebMenu()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/WebMenu/Webmenu");

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<WebMenu>>(responseBody));
            }
            else
                return null;
        }

        public async Task<List<WebMenu>> GetHomemenu()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/WebMenu/Homemenu");

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<WebMenu>>(responseBody));
            }
            else
                return null;
        }


    }
}
