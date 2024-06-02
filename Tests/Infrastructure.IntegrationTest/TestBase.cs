using BuildTestDataLibrary.DataSamples;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Repositories.CarBrandRepos;
using CarHireInfrastructure.Repositories.CarExtraRepos;
using CarHireInfrastructure.Repositories.CarModelRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarHireInfrastructure.IntegrationTest
{
    public abstract class TestBase
    {
        private bool _useSqlite = false;

        public async Task<ApplicationDbContext> GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            if (_useSqlite)
            {
                // Use Sqlite DB.
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                // Use In-Memory DB.
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(w =>
                {
                    w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                });
            }

            var dbContext = new ApplicationDbContext(builder.Options, null);
            //var dbContext = new ApplicationDbContext(builder.Options);

            if (_useSqlite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database and MS SQL.
                await dbContext.Database.OpenConnectionAsync();
            }

            await dbContext.Database.EnsureCreatedAsync();

            if (_useSqlite)
            {
                await SeedDatabase(dbContext);
                //dbContext.CarrierProviders
            }

            return dbContext;
        }

        public void UseSqlite()
        {
            _useSqlite = true;
        }


        public async Task SeedDatabase(ApplicationDbContext context)
        {
            var carExtraRepo = new CarExtraRepository(context);
            await carExtraRepo.AddRangeAsync(CarExtraListGenerator.Creates);

            var carBrandRepo = new CarBrandRepository(context);
            await carBrandRepo.AddRangeAsync(CarBrandListGenerator.Creates);

            var carModelRepo = new CarModelRepository(context);
            await carModelRepo.AddRangeAsync(CarModelListGenerator.Creates);
        }

    }
}
