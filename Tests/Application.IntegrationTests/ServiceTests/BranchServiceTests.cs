using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Queries;
using Application.IntegrationTests.TestData;
using AutoMapper;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarModelService;
using CarHire.Services.Cars;
using Domain.Common;
using Infrastructure.Data;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarModelRepos;
using Infrastructure.Repositories.CarRepos;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class BranchServiceTests : TestBase
    {

        public BranchServiceTests()
        {
            UseSqlite();
        }

        private string? myBranchName;
        private BranchData? branchData;
        private CarDto carDto;
        private CreateCarRequest createCarRequest;
        private CarData carData;
        private CarBrandData carBrandData;
        private CarModelData carModelData;
        private Mock<IMapper> mapper;

        [SetUp]
        public void SetUp()
        {
            myBranchName = "Derby";
            branchData = new BranchData();
            carData = new CarData();
            carModelData = new CarModelData();
            carBrandData = new CarBrandData();
        }


        public async Task CreateCarModel(ApplicationDbContext context, bool branchPrepare = true)
        {

            #region CarBrand
            var myCarBrandRepository = new CarBrandRepository(context);
            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            var myCarBrancdList = carBrandData.CreateCarBrandData().ToList();

            for (int i = 0; i < myCarBrancdList.Count; i++)
            {
                await myCarBrandService.Add(myCarBrancdList[i]);
            }
            #endregion


            #region CarModel
            var myCarModelRepository = new CarModelRepository(context);
            var myCarModelService = new CarModelService(myCarModelRepository);

            var myCarModelList = carModelData.CreateCarModelData().ToList();

            for (int i = 0; i < myCarModelList.Count; i++)
            {
                await myCarModelService.Add(myCarModelList[i]);
            }
            #endregion


            #region Car
            var myCarRepository = new CarRepository(context, null);
            var myCarService = new CarService(myCarRepository);

            await myCarService.Add(carData.CreateOneCarNoBranch());


            //var myCarList = carData.CreateCarDataList().ToList();

            //for (int i = 0; i < myCarList.Count; i++)
            //{
            //    await myCarService.Add(myCarList[i]);
            //}
            #endregion


            #region Branch
            if (branchPrepare)
            {
                var myBranchRepository = new BranchRepository(context);
                var myAddressRepository = new AddressRepository(context);

                var myBranchService = new BranchService(myBranchRepository, myAddressRepository);

                var myBranchList = branchData.CreateBranchData().ToList();

                for (int i = 0; i < myBranchList.Count; i++)
                {
                    await myBranchService.CreateBranch(myBranchList[i]);
                }
            }
            #endregion

        }


        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var createBranchRequests = branchData.CreateSingleBranchData();

            // Execute
            var myReturn = await myBranchService.CreateBranch(createBranchRequests);

            var data = await myBranchService.GetBranchById(myReturn.Id);

            // Assert
            Assert.AreEqual(myBranchName, data.BranchName);

        }


        [TestCase("Derby 2")]
        public async Task ShouldBeAbleToAddUpdateEntity(string NewBranchName)
        {

            using var context = await GetDbContext();

            await CreateCarModel(context, false);

            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var createBranchRequests = branchData.CreateSingleBranchData();

            // Execute
            var myReturn = await myBranchService.CreateBranch(createBranchRequests);

            var data = await myBranchService.GetBranchById(myReturn.Id);


            var updateBranchRequest = new UpdateBranchRequest()
            {

                Id = myReturn.Id,
                BranchName = NewBranchName,
                Address = data.Address,
                carChosenValues = new List<ChosenItem>()
            };

            updateBranchRequest.carChosenValues.Add(new ChosenItem() { ChosenId = 1, IsChosen = true });

            var myUpdateReturn = await myBranchService.UpdateBranch(updateBranchRequest);


            var dataUpdated = await myBranchService.GetBranchById(myReturn.Id);


            // Assert
            Assert.AreEqual(NewBranchName, dataUpdated.BranchName);

        }


        [Test]
        public async Task Should_BeAbleToAddMulti_GetList()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var myList = branchData.CreateBranchData().ToList();

            // Execute
            for (int i = 0; i < myList.Count; i++)
            {
                var myReturn = await myBranchService.CreateBranch(myList[i]);
            }


            var data = await myBranchService.GetBranches();

            // Assert
            Assert.AreEqual(myList.Count, (int)data.Count());

        }


        [Test]
        public async Task Should_BeAbleToAddMultiRemoveOne_GetList()
        {

            using var context = await GetDbContext();
            var mybranc = new BranchRepository(context);
            var mybranc1 = new AddressRepository(context);

            var myBranchService = new BranchService(mybranc, mybranc1);

            // Prepare
            var myList = branchData.CreateBranchData().ToList();

            // Execute
            for (int i = 0; i < myList.Count; i++)
            {
                await myBranchService.CreateBranch(myList[i]);
            }


            await myBranchService.DeleteBranchById(2);

            var data = await myBranchService.GetBranches();

            // Assert
            Assert.AreEqual(myList.Count - 1, (int)data.Count());
        }


        [TearDown]
        public void Cleanup()
        {
            branchData = null;
            carData = null;
            carModelData = null;
            carBrandData = null;

            GC.Collect();
        }


    }


}
