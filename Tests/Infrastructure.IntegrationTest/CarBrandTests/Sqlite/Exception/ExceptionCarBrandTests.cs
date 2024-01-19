using Domain.Entities.CarBrandsAggregate;
using Infrastructure.Repositories.CarBrandRepos;
using Microsoft.EntityFrameworkCore;
using SharedFunctionLibrary;

namespace Infrastructure.IntegrationTest.CarBrandTests.Sqlite.Exception
{
    public class ExceptionCarBrandTests : TestBase
    {
        public ExceptionCarBrandTests()
        {
            UseSqlite();
        }

        [Fact]
        public async Task CreateCarBrand_NullName_SaveFail()
        {
            //Arrange
            string londCarBrandName = TextGenerator.RandomString(51);

            using var context = await GetDbContext();
            var carBrandRepo = new CarBrandRepository(context);


            //Act
            var ex = await Assert.ThrowsAsync<DbUpdateException>(() => carBrandRepo.AddAsync(new CarBrand()));

            //Assert
            Assert.NotNull(ex);
            Assert.Contains("Name", ex.InnerException.Message);
        }
    }
}
