
using Application.Aggregates.RoleAggregate.Commands;
using Application.Aggregates.RoleAggregate.Queries;

namespace CarHire.Services.RoleGroups;

public interface IRoleGroupService
{

    Task<CreateRoleGroupResponse> Add(CreateRoleGroupRequest roleGroup);

    Task<RoleGroupDto> GetRoleGroupById(int Id);

}
