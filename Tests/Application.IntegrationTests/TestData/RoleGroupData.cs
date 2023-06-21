using Application.Aggregates.RoleAggregate.Commands;
using Domain.Enums;

namespace Application.IntegrationTests.TestData
{
    public class RoleGroupData
    {
        public CreateRoleGroupRequest CreateRoleGroupAdmin()
        {
            return new CreateRoleGroupRequest() { RoleGroupName = "Admin", UserTypeID = (int)UserType.AdminUser };
        }

        public CreateRoleGroupRequest CreateRoleGroupBranch()
        {
            return new CreateRoleGroupRequest() { RoleGroupName = "Branch", UserTypeID = (int)UserType.BranchUser };
        }

        public CreateRoleGroupRequest CreateRoleGroupCustomer()
        {
            return new CreateRoleGroupRequest() { RoleGroupName = "Customer", UserTypeID = (int)UserType.Customer };
        }

    }
}
