using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.IntegrationTests.TestData;
using Application.Repositories;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarModelService;
using CarHire.Services.RoleGroups;
using CarHire.Services.Users;
using Infrastructure.Data;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarHireRepos;
using Infrastructure.Repositories.CarModelRepos;
using Infrastructure.Repositories.RoleGroupRepos;
using Infrastructure.Repositories.UserRepos;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IntegrationTests.CarHires.Commands
{

    public class CreateCarHireTests //: TestBase
    {

        private readonly CreateCarBrandCommandHandler _handler;
        private readonly Mock<ICarHireRepository> _repo;
        private readonly ICarHireRepository _CarHireRepo;
        private readonly ApplicationDbContext _DbContext;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        private CarDto carDto;
        private CreateCarRequest createCarRequest;
        private CarData carData;
        private CarBrandData carBrandData;
        private CarModelData carModelData;
        private BranchData branchData;
        private RoleGroupData roleGroupData;
        private UserData userData;


        public CreateCarHireTests()
        {
            //_repo = MockCarHireRepository.GetCarHireRepository();

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                      //.UseSqlite("DataSource=:memory:", x => { })
                                      .UseInMemoryDatabase(databaseName: "TestCatalog")
                                      .Options;

            _DbContext = new ApplicationDbContext(dbOptions, null);
            _CarHireRepo = new CarHireRepository(_DbContext, _configuration);

            if (!_DbContext.Database.IsInMemory())
            {
                _DbContext.Database.Migrate();
            }

            // SQLite needs to open connection to the DB.
            // Not required for in-memory-database and MS SQL.
            //_DbContext.Database.OpenConnectionAsync();

            //_DbContext.Database.EnsureCreatedAsync();

            //_repo = Mock<ICarHireRepository>();
            _handler = new CreateCarBrandCommandHandler(_DbContext, _CarHireRepo);

        }

        public async Task ExecuteAsync()
        {
            carData = new CarData();
            carModelData = new CarModelData();
            carBrandData = new CarBrandData();
            branchData = new BranchData();
            roleGroupData = new RoleGroupData();
            userData = new UserData();


            #region CarBrand
            var myCarBrandRepository = new CarBrandRepository(_DbContext);
            var myCarBrandService = new CarBrandService(myCarBrandRepository);

            var myCarBrancdList = carBrandData.CreateCarBrandData().ToList();

            for (int i = 0; i < myCarBrancdList.Count; i++)
            {
                await myCarBrandService.Add(myCarBrancdList[i]);
            }
            #endregion


            #region CarModel
            var myCarModelRepository = new CarModelRepository(_DbContext);
            var myCarModelService = new CarModelService(myCarModelRepository);

            var myCarModelList = carModelData.CreateCarModelData().ToList();

            for (int i = 0; i < myCarModelList.Count; i++)
            {
                await myCarModelService.Add(myCarModelList[i]);
            }
            #endregion

            #region Branch

            var myBranchRepository = new BranchRepository(_DbContext);
            var myAddressRepository = new AddressRepository(_DbContext);

            var myBranchService = new BranchService(myBranchRepository, myAddressRepository);

            var myBranchList = branchData.CreateBranchData().ToList();

            for (int i = 0; i < myBranchList.Count; i++)
            {
                await myBranchService.CreateBranch(myBranchList[i]);
            }

            #endregion


            #region RoleGroup

            var roleGroupRepository = new RoleGroupRepository(_DbContext);
            var roleGroupService = new RoleGroupService(roleGroupRepository);

            var myRoleGroup = roleGroupData.CreateRoleGroupAdmin();

            await roleGroupService.Add(myRoleGroup);

            #endregion


            #region User

            var userRepository = new UserRepository(_DbContext);
            var userService = new UserService(userRepository);

            var adminUser = userData.CreateAdminUser();

            await userService.AddAdminUser(adminUser);

            #endregion 

        }



        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public async Task ShouldCreateCarHireList()
        {


            await ExecuteAsync();


            var command = new CreateCarHireCommand(1,
                                                                     1,
                                                                     1,
                                                                     DateTime.Now.AddDays(1),
                                                                     DateTime.Now.AddDays(1),
                                                                     1,
                                                                     DateTime.Now.AddDays(2),
                                                                     DateTime.Now.AddDays(2),
                                                                     120,
                                                                     15,
                                                                     null);

            var result = await _handler.Handle(command, CancellationToken.None);




            Assert.AreEqual(1, result);

        }


    }

}
