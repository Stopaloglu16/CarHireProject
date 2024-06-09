using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebApi.FunctionalTests.Helpers
{
    public class MockCurrentUserService : ICurrentUserService
    {
        public MockCurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "MockUserId";
            UserName = " MockUserName";
        }

        public string UserId { get; }
        public string UserName { get; }
    }

    //User email login
    //"carhireadmin@hotmail.co.uk", "Admin@123"

    public static class MockAdminUser
    {
        public static string UserEmail = "carhireadmin@hotmail.co.uk";
        public static string Password = "Admin@123";
    }

    
}
