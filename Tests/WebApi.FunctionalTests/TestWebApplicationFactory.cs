using Application.Common.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Common;

namespace WebApi.FunctionalTests
{
    public class MockCurrentUserService : ICurrentUserService
    {
        public MockCurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "MockUserId"; // httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserName = " MockUserName"; // httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
        }

        public string UserId { get; }
        public string UserName { get; }

    }

    public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

                // Create open SqliteConnection so EF won't automatically close it.
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });


                services.AddDbContext<ApplicationDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                services.AddScoped<ICurrentUserService, MockCurrentUserService>();


                var dbContextUser = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<WebIdentityContext>));

                if (dbContextUser != null) services.Remove(dbContextUser);


                services.AddDbContext<WebIdentityContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

            });

            return base.CreateHost(builder);
        }
    }
}
