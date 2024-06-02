using Domain.Entities;
using CarHireInfrastructure.Repositories.CarModelRepos;
using Microsoft.EntityFrameworkCore;
using SharedFunctionLibrary;

namespace CarHireInfrastructure.IntegrationTest.CarModelTests.Sqlite.Exception
{
    public class ExceptionCreateCarModelTests : TestBase
    {
        public ExceptionCreateCarModelTests()
        {
            UseSqlite();
        }

        [Fact]
        public async Task CreateCarModel_CarBrandNotSetUp_RequiredCarBrand()
        {
            //Arrange
            string longCarModelName = TextGenerator.RandomString(51);

            using var context = await GetDbContext();
            var carModelRepo = new CarModelRepository(context);

            var newCarModel = new CarModel()
            {
                CarBrandId = 999,
                Name = "Mockname",
                CarPhotoLenght = 1000,
                CarPhoto = "asdqwe",
                SeatNumber = 5
            };

            //Act
            var ex = await Assert.ThrowsAsync<DbUpdateException>(() => carModelRepo.AddAsync(newCarModel));

            //Assert
            Assert.NotNull(ex);
            Assert.Contains("FOREIGN KEY", ex.InnerException.Message);
        }


    }
}
