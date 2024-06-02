using Domain.Entities;
using CarHireInfrastructure.Repositories.CarBrandRepos;
using Microsoft.EntityFrameworkCore;

namespace CarHireInfrastructure.IntegrationTest.CarBrandTests.InMemory.CreateUpdate
{
    public class CreateCarBrandTests : TestBase
    {

        [Theory]
        [InlineData("Toyota")]
        public async Task CreateCarBrand_ValidCarBrand_SaveSuccess(string name)
        {

            //Arrange
            using var context = await GetDbContext();
            var carBrandRepo = new CarBrandRepository(context);

            //Act
            await carBrandRepo.AddAsync(new CarBrand()
            {
                Name = name
            });

            var myList = await carBrandRepo.GetAll().ToListAsync();

            //Assert
            Assert.NotNull(myList);

            Assert.Equal(name, myList.First().Name);

        }

    }
}
