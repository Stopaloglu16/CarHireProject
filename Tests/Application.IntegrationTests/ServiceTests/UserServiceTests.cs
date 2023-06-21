using Application.IntegrationTests.TestData;
using CarHire.Services.RoleGroups;
using CarHire.Services.Users;
using Infrastructure.Data;
using Infrastructure.Repositories.RoleGroupRepos;
using Infrastructure.Repositories.UserRepos;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{

    public class UserServiceTests : TestBase
    {

        public UserServiceTests()
        {
            UseSqlite();
        }

        private UserData userData;
        private RoleGroupData roleGroupData;


        [SetUp]
        public void SetUp()
        {
            userData = new UserData();
            roleGroupData = new RoleGroupData();
        }

        public async Task CreateRoleGroup(ApplicationDbContext context)
        {
            var roleGroupRepository = new RoleGroupRepository(context);
            var roleGroupService = new RoleGroupService(roleGroupRepository);

            var myRoleGroup = roleGroupData.CreateRoleGroupAdmin();

            await roleGroupService.Add(myRoleGroup);

        }



        [Test]
        public async Task ShouldBeAbleToAddAndGetEntity()
        {

            using var context = await GetDbContext();

            CreateRoleGroup(context);


            var userRepository = new UserRepository(context);
            var userService = new UserService(userRepository);


            // Prepare
            var adminUser = userData.CreateAdminUser();

            // Execute
            var myReturn = await userService.AddAdminUser(adminUser);

            var data = await userService.GetUserById(myReturn.Id);

            // Assert
            Assert.AreEqual("User Admin", data.FullName);


        }

    }
}
