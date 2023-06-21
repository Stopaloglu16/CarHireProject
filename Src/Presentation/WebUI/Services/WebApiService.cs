using Blazored.LocalStorage;
using Domain.Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebUI.Services
{
    public class WebApiService<TRequest, TResponse> : IWebApiService<TRequest, TResponse>
    {

        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }
        public ILocalStorageService _localStorageService { get; }

        public string Apitext { get; set; } = ""; // "/api";

        public WebApiService(HttpClient httpClient
            , IOptions<AppSettings> appSettings
            , ILocalStorageService localStorageService)
        {
            _appSettings = appSettings.Value;
            _localStorageService = localStorageService;

            //httpClient.BaseAddress = new Uri(_appSettings.ApiAddressForDatabase );
            httpClient.BaseAddress = new Uri(_appSettings.ApiAddressForDatabase);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");

            _httpClient = httpClient;
        }

        public async Task<List<TResponse>> GetAllDataAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            if (responseStatusCode.ToString() == "OK")
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return await Task.FromResult(JsonConvert.DeserializeObject<List<TResponse>>(responseBody));
            }
            else
                return null;
        }

        public async Task<TResponse> GetDataByIdAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));
        }

        public async Task<TResponse> SaveAsync(string requestUri, TRequest obj)
        {
            BasicErrorHandler basicErrorHandler = new BasicErrorHandler();

            string serializedUser = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));
        }

        public async Task<TResponse> SaveBulkAsync(string requestUri, List<TRequest> obj)
        {
            string serializedUser = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedObj = JsonConvert.DeserializeObject<TResponse>(responseBody);

            return await Task.FromResult(returnedObj);
        }

        public async Task<TResponse> UpdateAsync(string requestUri, int Id, TRequest obj)
        {
            BasicErrorHandler basicErrorHandler = new BasicErrorHandler();

            string serializedUser = JsonConvert.SerializeObject(obj);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, Apitext + requestUri + Id);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);


            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));
        }

        //public async Task<TResponse> DeleteAsync(string requestUri)
        //{
        //    var requestMessage = new HttpRequestMessage(HttpMethod.Delete, Apitext + requestUri);

        //    var token = await _localStorageService.GetItemAsync<string>("accessToken");
        //    requestMessage.Headers.Authorization
        //        = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        //    var response = await _httpClient.SendAsync(requestMessage);


        //    var responseStatusCode = response.StatusCode;
        //    var responseBody = await response.Content.ReadAsStringAsync();

        //    return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));
        //}

        public async Task<bool> DeleteAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);


            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            //return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));

            return true;
        }


        public async Task<TResponse> DeleteWithCheckingAsync(string requestUri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, Apitext + requestUri);

            var token = await _localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(requestMessage);


            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<TResponse>(responseBody));
        }
    }
}
