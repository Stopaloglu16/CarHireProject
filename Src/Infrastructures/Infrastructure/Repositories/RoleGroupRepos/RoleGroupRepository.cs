using Application.Aggregates.RoleAggregate.Queries;
using Application.Repositories;
using Domain.Entities.RoleAggregate;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;

namespace Infrastructure.Repositories.RoleGroupRepos
{

    public class RoleGroupRepository : EfCoreRepository<RoleGroup>, IRoleGroupRepository
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

            return new RoleGroupDto() { RoleGroupName = myReturn.RoleGroupName, UserTypeID = myReturn.UserTypeID };
        }

        public Task<IEnumerable<RoleGroupDto>> GetRoleGroups()
        {
            throw new NotImplementedException();
        }
    }


}
