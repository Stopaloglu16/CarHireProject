﻿using Application.Aggregates.CarExtraAggregate.Queries;
using Application.IntegrationTests.TestData;
using CarHire.Services.CarExtras;
using Infrastructure.Repositories.CarExtraRepos;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class CarExtraServiceTests : TestBase
    {

        public CarExtraServiceTests()
        {
            UseSqlite();
        }


        private CarExtraDto carExtraDto;
        private CarExtraData carExtraData;

        [SetUp]
        public void SetUp()
        {
            carExtraDto = new CarExtraDto() { Name = "Baby seat" };
            carExtraData = new CarExtraData();
        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();
            var myCarExtraRepository = new CarExtraRepository(context);

            var myCarExtraService = new CarExtraService(myCarExtraRepository);

            // Prepare
            var myList = carExtraData.CreateCarExtraData().ToList();

            // Execute
            var myReturn = await myCarExtraService.CreateCarExtra(myList[0]);

            var data = await myCarExtraService.GetCarExtraById(myReturn.Id);

            // Assert
            Assert.AreEqual(carExtraDto.Name, data.Name);

        }


        [TearDown]
        public void Cleanup()
        {
            carExtraDto = null;
            carExtraData = null;
        }

    }
}
