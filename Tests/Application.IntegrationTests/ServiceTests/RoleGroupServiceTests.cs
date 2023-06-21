using Application.IntegrationTests.TestData;
using CarHire.Services.RoleGroups;
using Infrastructure.Repositories.RoleGroupRepos;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.ServiceTests
{
    public class RoleGroupServiceTests : TestBase
    {

        public RoleGroupServiceTests()
        {
            UseSqlite();
        }

        private string? myRoleGroupName;
        private RoleGroupData? roleGroupData;


        [SetUp]
        public void SetUp()
        {
            myRoleGroupName = "Admin";
            roleGroupData = new RoleGroupData();
        }


        [Test]
        public async Task ShouldBeAbleToAddAdminAndGetEntity()
        {

            using var context = await GetDbContext();

            var roleGroupRepository = new RoleGroupRepository(context);
            var roleGroupService = new RoleGroupService(roleGroupRepository);

            // Prepare
            var myList = roleGroupData.CreateRoleGroupAdmin();

            // Execute
            var myReturn = await roleGroupService.Add(myList);

            var data = await roleGroupService.GetRoleGroupById(myReturn.Id);

            // Assert
            Assert.AreEqual(myRoleGroupName, data.RoleGroupName);

        }

    }
}
