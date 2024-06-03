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
}
