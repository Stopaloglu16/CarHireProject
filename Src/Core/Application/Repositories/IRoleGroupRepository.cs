using Application.Aggregates.RoleAggregate.Queries;
using Application.Common.Interfaces;
using Domain.Entities.UserAggregate;

namespace Application.Repositories
{
    public interface IRoleGroupRepository : IRepository<RoleGroup, int>
    {

        Task<IEnumerable<RoleGroupDto>> GetRoleGroups();

        Task<RoleGroupDto> GetRoleGroupById(int Id);

    }
}
