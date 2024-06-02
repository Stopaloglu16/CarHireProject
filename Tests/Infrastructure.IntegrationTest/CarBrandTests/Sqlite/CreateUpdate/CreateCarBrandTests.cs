using BuildTestDataLibrary.DataSamples;
using CarHireInfrastructure.Repositories.CarBrandRepos;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.IntegrationTest.CarBrandTests.Sqlite.CreateUpdate
{
    public class CreateCarBrandTests : TestBase
    {
        public CreateCarBrandTests()
        {
            UseSqlite();
        }

        [Fact]
        public async Task CreateCarBrand_ValidCarBrand_SaveSuccess()
        {
            //Arrange
            int listCount = CarBrandListGenerator.Creates.ToList().Count;
            const string CarBrandTestName = "Toyota";

            using var context = await GetDbContext();
            var carBrandRepo = new CarBrandRepository(context);

            //Act
            var myList = await carBrandRepo.GetAll().ToListAsync();

            //Assert
            Assert.NotNull(myList);
            Assert.Equal(CarBrandTestName, myList[0].Name);
            Assert.Equal(listCount, myList.Count);
        }
    }
}
