using CarHireInfrastructure.IntegrationTest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IntegrationTest
{
    public abstract class EmailTestBase 
    {

        protected string EmailApiToken { get; private set; }

        protected EmailTestBase()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<TestBase>()
           .Build();

            EmailApiToken = configuration["APIToken"];

        }
    }
}
