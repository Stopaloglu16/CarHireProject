using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IntegrationTest.EmailTests
{
    public class EmailEndpointTests: EmailTestBase
    {
        [Fact]
        public void CheckApiTokenValid()
        {
            var apiToken = EmailApiToken;

            // Act and Assert
            Assert.False(string.IsNullOrEmpty(apiToken), "API token should not be null or empty.");
        }




    }
}
