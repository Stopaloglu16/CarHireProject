using Application.Aggregates.UserAggregate.Commands;
using Azure.Core;
using Domain.Entities.UserAuthAggregate.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApi.FunctionalTests.Helpers;

namespace WebApi.FunctionalTests.UserEndPoints.Admin
{
    //api/v1/Users/CreateAdmin

    //{
    //"fullName": "string",
    //"userEmail": "string",
    //"userType": 0,
    //"roleGroupId": 0
    //}


    public class RegisterTests : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly TestWebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private string _bearerToken;

        public RegisterTests(TestWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
            _factory.RunApiUserMigrations();
            _bearerToken = "";
        }

        [Theory]
        [InlineData("James Wayne", "jameswayne@carhire.co.uk")]
        public async Task CreateAdminRegister_ValidValues_Success(string userName, string email)
        {
            
            UserLoginRequest userLoginRequest = new() { Username = MockAdminUser.UserEmail , Password = MockAdminUser.Password };

            var responseApiLogin = await _httpClient.PostAsJsonAsync("/api/Login", userLoginRequest);

            
            var apiLoginResponse = await responseApiLogin.Content.ReadFromJsonAsync<UserLogInResponse>();

            CreateAdminUserRequest createAdminUserRequest = new CreateAdminUserRequest()
            {
                FullName = userName,
                UserEmail = email,
                RoleGroupId = 1
            };


            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiLoginResponse.AccessToken);

            var responseCreateUser = await _httpClient.PostAsJsonAsync("/api/v1/Users/CreateAdmin", createAdminUserRequest );

            Assert.True(System.Net.HttpStatusCode.OK == responseCreateUser.StatusCode, $"Register Admin user {responseApiLogin.StatusCode}");

        }
    }
}
