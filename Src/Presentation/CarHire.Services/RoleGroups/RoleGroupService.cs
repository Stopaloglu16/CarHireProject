using Application.Aggregates.RoleAggregate.Commands;
using Application.Aggregates.RoleAggregate.Queries;
using Application.Repositories;
using Domain.Entities.RoleAggregate;

namespace CarHire.Services.RoleGroups
{

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
                RoleGroupName = roleGroup.RoleGroupName,
                UserTypeID = roleGroup.UserTypeID
            });

            if (myReturn == null) return new CreateRoleGroupResponse(0, new Domain.Common.BasicErrorHandler("SystemIssue"));

            return new CreateRoleGroupResponse(myReturn.Id, new Domain.Common.BasicErrorHandler());
        }

        public async Task<RoleGroupDto> GetRoleGroupById(int Id)
        {
            return await _roleGroupRepository.GetRoleGroupById(Id);
        }
    }
}
