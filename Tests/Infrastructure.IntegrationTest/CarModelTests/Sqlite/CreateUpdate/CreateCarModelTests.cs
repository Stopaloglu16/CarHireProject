using Domain.Entities;
using CarHireInfrastructure.Repositories.CarBrandRepos;
using CarHireInfrastructure.Repositories.CarModelRepos;

namespace CarHireInfrastructure.IntegrationTest.CarModelTests.Sqlite.CreateUpdate
{
    public class CreateCarModelTests : TestBase
    {
        public CreateCarModelTests()
        {
            UseSqlite();
        }

        [Theory]
        [InlineData("CHR")]
        public async Task CreateCarModel_ValidCarModel_SaveSuccess(string name)
        {
            //Arrange
            using var context = await GetDbContext();
            var carBrandRepo = new CarBrandRepository(context);

            var carModelRepo = new CarModelRepository(context);

            var newCarBrand = await carBrandRepo.AddAsync(new CarBrand() { Name = "Toyota" });

            var newCarModel = new CarModel()
            {
                CarBrandId = newCarBrand.Id,
                Name = name,
                CarPhotoLenght = 1000,
                CarPhoto = "asdqwe",
                SeatNumber = 5
            };

            //Act
            var newCarmodel1 = await carModelRepo.AddAsync(newCarModel);

            var myList = await carModelRepo.GetByIdAsync(newCarmodel1.Id);

            //Assert
            Assert.NotNull(myList);
            Assert.Equal(name, myList.Name);
        }

    }
}
