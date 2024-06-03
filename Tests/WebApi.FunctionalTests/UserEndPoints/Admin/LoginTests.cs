﻿using CarHire.Services.Users;
using CarHireInfrastructure.Data;
using Domain.Entities.UserAggregate;
using Domain.Entities.UserAuthAggregate.Login;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApi.FunctionalTests.Helpers;

namespace WebApi.FunctionalTests.UserEndPoints.Admin
{
    public class LoginTests : IClassFixture<TestWebApplicationFactory<Program>>
    {
        private readonly TestWebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;
        private string _bearerToken;

        public LoginTests(TestWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
            //_factory.RunMigrations();
            _factory.RunApiUserMigrations();
            _bearerToken = "";
        }

        [Theory]
        [InlineData("carhireadmin@hotmail.co.uk", "carhireadmin@hotmail.co.uk", "Admin@123")]
        public async Task PostAdminLogin_ValidValues_LoginSuccess(string userName, string email, string password)
        {

            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var myuu = db.Users.ToList();
                await db.SaveChangesAsync();

            }


            UserLoginRequest userLoginRequest = new() { Username = userName, Password = password };

            var responseApiLogin = await _httpClient.PostAsJsonAsync("/api/Login", userLoginRequest);


            Assert.True(System.Net.HttpStatusCode.OK == responseApiLogin.StatusCode, $"Login API {responseApiLogin.StatusCode}");

            var apiLoginResponse = await responseApiLogin.Content.ReadFromJsonAsync<UserLogInResponse>();

            _bearerToken = apiLoginResponse.AccessToken;

        }




    }


}

