using Application.Aggregates.RoleAggregate.Commands;
using Application.Aggregates.RoleAggregate.Queries;
using Application.Repositories;
using Domain.Entities.UserAggregate;

namespace CarHire.Services.RoleGroups;


public class RoleGroupService : IRoleGroupService
{

    private readonly IRoleGroupRepository _roleGroupRepository;

    public RoleGroupService(IRoleGroupRepository roleGroupRepository)
    {
        _roleGroupRepository = roleGroupRepository;
    }

    public async Task<CreateRoleGroupResponse> Add(CreateRoleGroupRequest roleGroup)
    {
        var myReturn = await _roleGroupRepository.AddAsync(new RoleGroup()
        {
            RoleGroupName = roleGroup.RoleGroupName
            //UserTypeID = roleGroup.UserTypeID
        });

        if (myReturn == null) return new CreateRoleGroupResponse(0);

        return new CreateRoleGroupResponse(myReturn.Id);
    }

    public async Task<RoleGroupDto> GetRoleGroupById(int Id)
    {
        return await _roleGroupRepository.GetRoleGroupById(Id);
    }
}
