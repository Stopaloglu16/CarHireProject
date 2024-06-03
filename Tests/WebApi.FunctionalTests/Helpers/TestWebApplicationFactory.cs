using Application.Common.Interfaces;
using CarHireInfrastructure.Data;
using Domain.Entities.UserAggregate;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Common;

namespace WebApi.FunctionalTests.Helpers
{

    public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        public void RunMigrations()
        {
            using (var scope = this.Services.CreateScope())
            {
                var idb = scope.ServiceProvider.GetService<WebIdentityContext>();
                idb.Database.Migrate();

                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();
            }
        }


        public void RunApiUserMigrations()
        {
            using (var scope = this.Services.CreateScope())
            {
                var idb = scope.ServiceProvider.GetService<WebIdentityContext>();
                idb.Database.Migrate();

                var identityUser = idb.Users.Single();

                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Database.Migrate();


                RoleGroup roleGroup = new RoleGroup()
                {
                    RoleGroupName = "AdminRole",
                    UserTypeId = (int)UserType.AdminUser
                };

                db.RoleGroups.Add(roleGroup);
                db.SaveChanges();

                User user = new User()
                {
                    AspId = identityUser.Id,
                    FullName = "Admin User",
                    UserEmail = identityUser.Email,
                    UserTypeId = UserType.AdminUser,
                    RoleGroupId = roleGroup.Id
                };
                db.Users.Add(user);
                db.SaveChanges();

            }
        }



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
                    options.UseSqlite(connection,
                        x => x.MigrationsAssembly("CarHireInfrastructure.SqliteMigrations"));
                });

                services.AddScoped<ICurrentUserService, MockCurrentUserService>();



                //Identity DbContext
                var dbContextUser = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<WebIdentityContext>));

                if (dbContextUser != null) services.Remove(dbContextUser);

                //Create open SqliteConnection so EF won't automatically close it.
                //services.AddSingleton<DbConnection>(container =>
                //{
                //    var connection = new SqliteConnection("DataSource=:memory:");
                //    connection.Open();

                //    return connection;
                //});


                services.AddDbContext<WebIdentityContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection,
                       x => x.MigrationsAssembly("CarHireInfrastructure.SqliteMigrations"));
                });

            });

            return base.CreateHost(builder);
        }
    }
}
