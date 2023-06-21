using Application.Aggregates.RoleAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.RoleAggregate;

namespace Application.Repositories
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {

        Task<IEnumerable<RoleGroupDto>> GetRoleGroups();

        Task<RoleGroupDto> GetRoleGroupById(int Id);

    }
}
