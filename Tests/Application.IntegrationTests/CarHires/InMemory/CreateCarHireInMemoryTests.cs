using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.IntegrationTests.TestData;
using Application.Repositories;
using Castle.Core.Configuration;
using Infrastructure.Data;
using Infrastructure.Repositories.CarHireRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarHires
{

    public class CreateCarHireInMemoryTests
    {

        private readonly CreateCarBrandCommandHandler _handler;
        //private readonly Mock<ICarHireRepository> _repo;
        private readonly ICarHireRepository _CarHireRepo;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly ApplicationDbContext _DbContext;

        private CarHireData carHireData;
        //private CreateCarRequest createCarRequest;
        //private CarData carData;
        //private CarBrandData carBrandData;
        //private CarModelData carModelData;
        //private BranchData branchData;
        //private RoleGroupData roleGroupData;
        //private UserData userData;


        public CreateCarHireInMemoryTests()
        {
            //_repo = MockCarHireRepository.GetCarHireRepository();

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      //.UseSqlite("DataSource=:memory:", x => { })
                                      .UseInMemoryDatabase(databaseName: "TestCatalog")
                                      .Options;

           //var _configuration = new Dictionary<string, string> {
           //                                                     {"Key1", "Value1"},
           //                                                     {"Nested:Key1", "NestedValue1"},
           //                                                     {"Nested:Key2", "NestedValue2"}
           //                                                 };

            //var configuration = new ConfigurationBuilder()
              //              .AddInMemoryCollection(myConfiguration)
                //            .Build();

            _DbContext = new ApplicationDbContext(dbOptions, null);

            _CarHireRepo = new CarHireRepository(_DbContext, _configuration);

            if (!_DbContext.Database.IsInMemory())
            {
                _DbContext.Database.Migrate();
            }

            _handler = new CreateCarBrandCommandHandler(_DbContext, _CarHireRepo);

        }



        [SetUp]
        public void SetUp()
        {
            carHireData = new CarHireData();
        }


        [Test]
        public async Task Should_Create_OneCarHire()
        {
            var command = new CreateCarHireCommand(1,
                                                                     1,
                                                                     1,
                                                                     DateTime.Now.AddDays(1),
                                                                     DateTime.Now.AddDays(1),
                                                                     1,
                                                                     DateTime.Now.AddDays(2),
                                                                     DateTime.Now.AddDays(2),
                                                                     120,
                                                                     15);

            var result = await _handler.Handle(command, CancellationToken.None);

            var mylist = await _DbContext.CarHires.FindAsync(result);

            Assert.AreEqual(result, mylist.Id);
        }



        //[TestCase(10)]
        //public async Task Should_Create_CarHireList(int carHireListCount)
        //{

        //    await _DbContext.CarHires.Remove(1);

        //    var myCarhireList = carHireData.CreateCarHireListData(carHireListCount);

        //    foreach (var command in myCarhireList)
        //    {
        //        var result = await _handler.Handle(command, CancellationToken.None);
        //    }

        //    var mylist = await _DbContext.CarHires.ToListAsync();

        //    Assert.AreEqual(carHireListCount, mylist.Count);
        //}


        [Test]
        public async Task Fail_Create_CarHireSameDateRange()
        {
            var myCarhireList = carHireData.CreateCarHireRejectData().ToList();

            var result = await _handler.Handle(myCarhireList[0], CancellationToken.None);

            Assert.IsTrue(CheckCondition(result));

            var result1 = await _handler.Handle(myCarhireList[1], CancellationToken.None);

            Assert.IsTrue(CheckCondition(result1));

            var result2 = await _handler.Handle(myCarhireList[2], CancellationToken.None);

            Assert.IsFalse(CheckCondition(result2));

            var result3 = await _handler.Handle(myCarhireList[3], CancellationToken.None);

            Assert.IsTrue(CheckCondition(result3));
        }


        public bool CheckCondition(int Id)
        {
            return Id > 0 ? true : false;
        }

    }

}
