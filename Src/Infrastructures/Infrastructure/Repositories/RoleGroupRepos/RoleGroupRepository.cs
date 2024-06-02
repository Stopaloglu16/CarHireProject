using Application.Aggregates.RoleAggregate.Queries;
using Application.Repositories;
using Domain.Entities.UserAggregate;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Data.EfCore;

namespace CarHireInfrastructure.Repositories.RoleGroupRepos;

public class RoleGroupRepository : EfCoreRepository<RoleGroup, int>, IRoleGroupRepository
{
    private readonly ApplicationDbContext _dbContext;
    public RoleGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RoleGroupDto> GetRoleGroupById(int Id)
    {
        var myReturn = await GetByIdAsync(Id);

        if (myReturn == null) return null;

        return new RoleGroupDto() { RoleGroupName = myReturn.RoleGroupName, UserTypeID = (int)myReturn.UserTypeId };
    }

    public Task<IEnumerable<RoleGroupDto>> GetRoleGroups()
    {
        throw new NotImplementedException();
    }
}
